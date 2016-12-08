using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;

public partial class Signin : System.Web.UI.Page
{
    private static string connectionstring = WebConfigurationManager.ConnectionStrings["oracle"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void SignIn_Click(object sender, EventArgs e)
    {
        var countCon=new OracleConnection(connectionstring);
        countCon.Open();
        int userNameExists ;

        var command =
            new OracleCommand("SELECT COUNT(*) FROM Users WHERE UserName =: UserName", countCon);
        command.Parameters.Add("UserName", UserNameBox.Text);
        userNameExists = Convert.ToInt32(command.ExecuteScalar());
        countCon.Close();


        if (userNameExists==1)
        {
            using (var conn=new OracleConnection(connectionstring))
            {
                conn.Open();
                //var com=new OracleCommand();
                //com.CommandType=CommandType.StoredProcedure;
                //com.CommandText = "READ_USER";
                //var Return = new OracleParameter()
                //{
                //    ParameterName = "RETURN",
                //    Direction = ParameterDirection.ReturnValue,
                //    OracleDbType = OracleDbType.Int32
                //};
                //var userName = new OracleParameter()
                //{
                //    ParameterName = "UNAME",
                //    Direction = ParameterDirection.Input,
                //    Value = UserNameBox.Text,
                //    OracleDbType = OracleDbType.Varchar2,
                //    Size = 90
                //};
                //com.Parameters.Add(Return);
                //com.Parameters.Add(userName);
                //com.ExecuteNonQuery();
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SignIn_Info";
                var Username = new OracleParameter()
                {
                    ParameterName = "U_NAME",
                    Direction = ParameterDirection.Input,
                    Value = UserNameBox.Text,
                    OracleDbType = OracleDbType.Varchar2,
                    Size = 90
                };
                var pass = new OracleParameter()
                {
                    ParameterName = "U_DATE",
                    Direction = ParameterDirection.Input,
                    Value = DateTime.Today,
                    OracleDbType = OracleDbType.Date
                };
                cmd.Parameters.Add(Username);
                cmd.Parameters.Add(pass);
                cmd.BindByName = true;
                cmd.ExecuteNonQuery();
                conn.Close();
                Session["userName"] = UserNameBox.Text;
                Response.RedirectPermanent("Default.aspx");
            }
           
        }
        else
        {
            UserNameBox.Text  = "User Doesn't exist";
        }
       
    }
}