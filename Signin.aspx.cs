using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;

public partial class Signin : System.Web.UI.Page
{
    private readonly OracleConnection connection =
        new OracleConnection(
            " DATA SOURCE=oracle1.centennialcollege.ca:1521/SQLD;PASSWORD=password;USER ID=Comp214F16_GROUP_4;Connect Timeout=15;");

    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void SignIn_Click(object sender, EventArgs e)
    {
        connection.Open();
        int userNameExists ;

        var command =
            new OracleCommand("SELECT COUNT(*) FROM Users WHERE UserName =: UserName", connection);
        command.Parameters.Add("UserName", UserNameBox.Text);
        userNameExists = Convert.ToInt32(command.ExecuteScalar());
        connection.Close();


        if (userNameExists==1)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
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
            Session["userName"] = UserNameBox.Text;
            Response.RedirectPermanent("Default.aspx");
            connection.Close();
        }
        else
        {
            UserNameBox.Text  = "User Doesn't exist";
        }
       
    }
}