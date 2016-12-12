using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;

public partial class Orders : System.Web.UI.Page
{
    private static string connectionstring = WebConfigurationManager.ConnectionStrings["oracle"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            var conn = new OracleConnection(connectionstring);
            conn.Open();

            var query10 = "select userid from users where USERNAME=" + "'" + Session["userName"].ToString() + "'";
            var command10 = new OracleCommand(query10, conn);
            var userid = Convert.ToInt16(command10.ExecuteScalar());
            var query8 = "select count(*) from ordersdetails where userid=" + userid;
            var command5 = new OracleCommand(query8, conn);
            var ordreid = Convert.ToInt16(command5.ExecuteScalar());
            var query3 = "select *  from ordersdetails where orderid = ( select max(orderid) from ordersdetails )";
            var command11 = new OracleCommand(query3, conn);
            var j = Convert.ToInt16(command11.ExecuteScalar());
            var query6 = "select *  from ordersdetails ";
            var command6 = new OracleCommand(query6, conn);
            var reader1 = command6.ExecuteReader();
            if (reader1.HasRows)
            {
                for (; j >= 10000; j--)
                {
                    var query = "Select * from Ordersdetails,orders where orders.Orderid=" + j + "and userid=" + userid + "and ordersdetails.Orderid = " + j;
                    var command12 = new OracleCommand(query, conn);
                    OracleDataReader reader = command12.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        var createDiv = new HtmlGenericControl("DIV");
                        var innerdiv = new HtmlGenericControl("DIV");
                        innerdiv.Attributes["class"] = "thumbnail";
                        //string reacipeName = (string)reader["RecipeName"];



                        createDiv.Attributes["class"] = "col-md-4 col-sm-6 col-xs-12";
                        innerdiv.InnerHtml = " <div class='caption' > <h3 ID='RecipeName' runat='server'>" +
                                             reader["RECIPENAME"] + "</h3>" + "<h4> OrderID:#" + reader["Orderid"] + "</h4>" + "</h4>" + "<h4>Price:$" + reader["Price"] + "</h4>" + "</div>";
                        createDiv.ID = "createDiv" + j;
                        innerdiv.ID = "innerDiv" + j;
                        dynamic.Controls.Add(createDiv);
                        createDiv.Controls.Add(innerdiv);
                    }


                }

            }
            conn.Close();
        }
        else
        {
           Response.Redirect("Signin.aspx");
        }
        
    }
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
}