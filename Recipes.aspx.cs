using System;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;

public partial class Recipes : Page
{
    private static readonly string connectionstring =
        WebConfigurationManager.ConnectionStrings["oracle"].ConnectionString;

    //(

    //"Data Source=DESKTOP-B5SA0JC\\SATNAM;Initial Catalog=Comp229;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");

    protected void Page_Load(object sender, EventArgs e)
    {
        var connection = new OracleConnection(connectionstring);
        connection.Open();
        var query1 = "Select * from Recipes";
        var command1 = new OracleCommand(query1, connection);
        var reader1 = command1.ExecuteReader();
        reader1.Read();

        var query3 = "select *  from Recipes where RecipeNumber = ( select max(RecipeNumber) from Recipes )";
        var command3 = new OracleCommand(query3, connection);
        var i = (int) command3.ExecuteScalar();
        if (reader1.HasRows)
        {
            for (; i >= 1; i--)
            {
                var query = "Select * from Recipes where RecipeNumber=" + i;
                var command = new OracleCommand(query, connection);
                var reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    var createDiv = new HtmlGenericControl("DIV");
                    var innerdiv = new HtmlGenericControl("DIV");
                    innerdiv.Attributes["class"] = "thumbnail";
                    //string reacipeName = (string)reader["RecipeName"];

                    var moreInfoButton = new Button();
                    moreInfoButton.Text = "Order";
                    moreInfoButton.ID = i + "";
                    moreInfoButton.ClientIDMode = ClientIDMode.Static;
                    moreInfoButton.Click += Order_recipe;
                    moreInfoButton.Attributes["class"] = "btn btn-primary";
                    createDiv.Attributes["class"] = "col-md-4 col-sm-6 col-xs-12";
                    innerdiv.InnerHtml = " <div class='caption' > <h3 ID='RecipeName' runat='server'>" +
                                         reader["RECIPENAME"] + "</h3>" + "<h4>" + reader["CUISINE"] + "</h4>" + "</h4>" +
                                         "<h4>Price:$" + reader["RECIPEPRICE"] + "</h4>" + "</div>" +
                                         "<p>" + reader["RecipeDescription"] +
                                         "</p>";
                    createDiv.ID = "createDiv" + i;
                    innerdiv.ID = "innerDiv" + i;
                    dynamic.Controls.Add(createDiv);
                    createDiv.Controls.Add(innerdiv);
                    innerdiv.Controls.Add(moreInfoButton);
                }
            }

            connection.Close();
        }
    }


    //    {
    //                var createDiv = new HtmlGenericControl("DIV");
    //                var innerdiv = new HtmlGenericControl("DIV");
    //                innerdiv.Attributes["class"] = "thumbnail";
    //                //string reacipeName = (string)reader["RecipeName"];

    //                Button moreInfoButton = new Button();
    //                moreInfoButton.Text = "More Info";
    //                moreInfoButton.ID = Convert.ToString(i);
    //                moreInfoButton.ClientIDMode = ClientIDMode.Static;
    //                moreInfoButton.Click += new EventHandler(moreInfo_Click);
    //                moreInfoButton.Attributes["class"] = "btn btn-info";
    //                createDiv.Attributes["class"] = "col-md-4 col-sm-6 col-xs-12";
    //                innerdiv.InnerHtml = "<img src=" + imageUrl +
    //                                     " alt='Recipe Image' class='img-responsive img-rounded img-thumbnail' style='height: 250px'> <div class='caption' > <h2 ID='RecipeName' runat='server'>" +
    //                                     reader["RecipeName"] + "</h2></div>" + "<p>" + reader["RecipeDescription"] +
    //                                     "</p>";
    //                createDiv.ID = "createDiv" + i;
    //                innerdiv.ID = "innerDiv" + i;
    //                dynamic.Controls.Add(createDiv);
    //                createDiv.Controls.Add(innerdiv);
    //                innerdiv.Controls.Add(moreInfoButton);

    //            }

    //        }


    //}


    protected override void OnPreInit(EventArgs e)
    {
        if (Session["userName"] != null)
        {
            MasterPageFile = "~/MasterSingin.master";
            base.OnPreInit(e);
        }
        else
        {
            MasterPageFile = "~/MasterPage.master";
            base.OnPreInit(e);
        }
    }


    protected void Order_recipe(object sender, EventArgs e)
    {
        var b = (Button) sender;
        var buttonId = b.ID;
        if (Session["userName"] != null)
            using (var conn = new OracleConnection(connectionstring))
            {
                conn.Open();
                var query1 = "select recipeName from Recipes where RecipeNumber=" + buttonId;
                var command3 = new OracleCommand(query1, conn);
                var i = Convert.ToString(command3.ExecuteScalar());

                var command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ORDER_INSERT";


                var UserName = new OracleParameter
                {
                    ParameterName = "USERNAME",
                    Direction = ParameterDirection.Input,
                    Value = Session["userName"].ToString(),
                    OracleDbType = OracleDbType.Varchar2,
                    Size = 90
                };

                var RNAME = new OracleParameter
                {
                    ParameterName = "RNAME",
                    Direction = ParameterDirection.Input,
                    Value = i,
                    OracleDbType = OracleDbType.Varchar2,
                    Size = 90
                };


                command.Parameters.Add(UserName);
                command.Parameters.Add(RNAME);
                command.BindByName = true;
                command.ExecuteNonQuery();
                var query9 = "select RecipePrice from Recipes where RecipeNumber=" + buttonId;
                var command4 = new OracleCommand(query9, conn);
                var price = Convert.ToString(command4.ExecuteScalar());
                var query10 = "select userid from users where USERNAME=" + "'" + Session["userName"] + "'";
                var command10 = new OracleCommand(query10, conn);
                var userid = Convert.ToInt16(command10.ExecuteScalar());
                var query8 = "select count(*) from ordersdetails where userid=" + userid;
                var command5 = new OracleCommand(query9, conn);
                var ordreid = Convert.ToInt16(command5.ExecuteScalar());
                var query3 = "select *  from ordersdetails where orderid = ( select max(orderid) from ordersdetails )";
                var command11 = new OracleCommand(query3, conn);
                var j = Convert.ToInt16(command11.ExecuteScalar());
                var query6 = "select *  from ordersdetails ";
                var command6 = new OracleCommand(query6, conn);
                var reader1 = command6.ExecuteReader();
                var com = conn.CreateCommand();
                com.CommandType=CommandType.Text;
                com.CommandText = "insert into orders(price) values(:price)";

               
                var price1 = new OracleParameter
                {
                    ParameterName = "price",
                    Direction = ParameterDirection.Input,
                    Value = price,
                    OracleDbType = OracleDbType.Varchar2,
                    Size = 90
                };
                com.Parameters.Add(price1);
                com.BindByName = true;
                com.ExecuteNonQuery();
                conn.Close();
            }
        else
            Response.Redirect("Signin.aspx");
    }
}
