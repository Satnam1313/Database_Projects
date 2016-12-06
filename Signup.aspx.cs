using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using Oracle.ManagedDataAccess.Client;

public partial class Signup : Page
{
    private static string connectionstring = WebConfigurationManager.ConnectionStrings["oracle"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SignIn_Click(object sender, EventArgs e)
    {
        bool userAlreadyExists = false;
        using (var conn = new OracleConnection(connectionstring))
        {
            conn.Open();
            var command = conn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "READ_USER";

            var returnParam = new OracleParameter()
            {
                ParameterName = "Return Value",
                Direction = ParameterDirection.ReturnValue,
                OracleDbType = OracleDbType.Decimal,
            };

            var arg1Param = new OracleParameter()
            {
                ParameterName = "UName",
                Direction = ParameterDirection.Input,
                Value = "Admin",
                OracleDbType = OracleDbType.Varchar2,
                Size = 90
            };
            command.Parameters.Add(arg1Param);
            command.Parameters.Add(returnParam);
            command.BindByName = true;
            command.ExecuteNonQuery();
            conn.Close();
            if (returnParam.Status == OracleParameterStatus.NullFetched)
            {

                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NewUser_INSERT";



                var Username = new OracleParameter()
                {
                    ParameterName = "U_NAME",
                    Direction = ParameterDirection.Input,
                    Value =UserNameBox.Text,
                    OracleDbType = OracleDbType.Varchar2,
                    Size = 90
                };
                var Email = new OracleParameter()
                {
                    ParameterName = "U_email",
                    Direction = ParameterDirection.Input,
                    Value = EmailBox.Text,
                    OracleDbType = OracleDbType.Varchar2,
                    Size = 90
                };
                var pass = new OracleParameter()
                {
                    ParameterName = "U_PASS",
                    Direction = ParameterDirection.Input,
                    Value = PasswordBox.Text,
                    OracleDbType = OracleDbType.Varchar2,
                    Size = 90
                };
                var add = new OracleParameter()
                {
                    ParameterName = "U_ADD",
                    Direction = ParameterDirection.Input,
                    Value = AddressBox.Text,
                    OracleDbType = OracleDbType.Varchar2,
                    Size = 90
                };
                var EnrtyDAte = new OracleParameter()
                {
                    ParameterName = "U_Date",
                    Direction = ParameterDirection.Input,
                    Value = DateTime.Today,
                    OracleDbType = OracleDbType.Date,
                    Size = 90
                };
                var phone = new OracleParameter()
                {
                    ParameterName = "U_Date",
                    Direction = ParameterDirection.Input,
                    Value = Phone.Text,
                    OracleDbType = OracleDbType.Varchar2,
                    Size = 90
                };
                command.Parameters.Add(Email);
                command.Parameters.Add(pass);
                command.Parameters.Add(add);
                command.Parameters.Add(UserName);
                command.Parameters.Add(EnrtyDAte);
                command.Parameters.Add(phone);
                command.BindByName = true;
                command.ExecuteNonQuery();
                Session["userName"] = UserNameBox.Text;
                Response.RedirectPermanent("Default.aspx");

            }
            else
            {
                dynamim.InnerText = "User Already exist. Try with other user name or email ";
            }

        }


    }
}
