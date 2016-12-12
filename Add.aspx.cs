using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Configuration;
using System.Web.UI;
using Oracle.ManagedDataAccess.Client;

public partial class Add : Page
{
    private static string connectionstring = WebConfigurationManager.ConnectionStrings["oracle"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected override void OnPreInit(EventArgs e)
    {
        if (Session["userName"] != null)
        {
            this.MasterPageFile = "~/MasterSingin.master";
            base.OnPreInit(e);
        }
        else
        {
            this.MasterPageFile = "~/MasterPage.master";
            base.OnPreInit(e);
        }
        
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            var countCon = new OracleConnection(connectionstring);
            countCon.Open();
            int recipe;

            var cmd =
                new OracleCommand("SELECT COUNT(*) FROM RECIPES WHERE RecipeName =: RecipeName", countCon);
            cmd.Parameters.Add("RecipeName", Recipebox.Text);
            recipe = Convert.ToInt32(cmd.ExecuteScalar());
            countCon.Close();
            //string user = Session["userName"].ToString();
            Random priceRandom = new Random();
            if (recipe == 0)
            {
                using (var conn = new OracleConnection(connectionstring))
                {
                    conn.Open();
                    var command = conn.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "RECIPE_INSERT";



                    var RCategory = new OracleParameter()
                    {
                        ParameterName = "RCategory",
                        Direction = ParameterDirection.Input,
                        Value = CategoryList.Text,
                        OracleDbType = OracleDbType.Varchar2,
                        Size = 90
                    };
                    var cuisine = new OracleParameter()
                    {
                        ParameterName = "CUISINE",
                        Direction = ParameterDirection.Input,
                        Value = CuisineList.Text,
                        OracleDbType = OracleDbType.Varchar2,
                        Size = 90
                    };
                    var Description = new OracleParameter()
                    {
                        ParameterName = "DESCRIPTION",
                        Direction = ParameterDirection.Input,
                        Value = Steps.Text,
                        OracleDbType = OracleDbType.Varchar2,
                        Size = 90
                    };
                    var UserName = new OracleParameter()
                    {
                        ParameterName = "USERNAME",
                        Direction = ParameterDirection.Input,
                        Value = Session["userName"].ToString(),
                        OracleDbType = OracleDbType.Varchar2,
                        Size = 90
                    };
                    var EnrtyDAte = new OracleParameter()
                    {
                        ParameterName = "ENTRYDATE",
                        Direction = ParameterDirection.Input,
                        Value = DateTime.Today,
                        OracleDbType = OracleDbType.Date,
                        Size = 90
                    };
                    var RNAME = new OracleParameter()
                    {
                        ParameterName = "RNAME",
                        Direction = ParameterDirection.Input,
                        Value = Recipebox.Text,
                        OracleDbType = OracleDbType.Varchar2,
                        Size = 90
                    };
                    var Price = new OracleParameter()
                    {
                        ParameterName = "PRICE",
                        Direction = ParameterDirection.Input,
                        Value = priceRandom.Next(5, 25),
                        OracleDbType = OracleDbType.Varchar2,
                        Size = 90
                    };
                    command.Parameters.Add(RCategory);
                    command.Parameters.Add(cuisine);
                    command.Parameters.Add(Description);
                    command.Parameters.Add(UserName);
                    command.Parameters.Add(EnrtyDAte);
                    command.Parameters.Add(RNAME);
                    command.Parameters.Add(Price);
                    command.BindByName = true;
                    command.ExecuteNonQuery();


                }
            }
            else
            {
                dynamic.InnerHtml = "Recipe already exits.";
            }
        }
        else
        {
            Response.Redirect("Signin.aspx");
        }

        

    }

    
}
    
    




