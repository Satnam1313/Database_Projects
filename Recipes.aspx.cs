using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;

public partial class Recipes : Page
{

    private static string connectionstring = WebConfigurationManager.ConnectionStrings["oracle"].ConnectionString;
    //(

    //"Data Source=DESKTOP-B5SA0JC\\SATNAM;Initial Catalog=Comp229;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public ICollection GetRecipes()
    {
        var recipesList = new List<Recipe>();
        using (var conn = new OracleConnection(connectionstring))
        {
            conn.Open();
            var command = conn.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from RECIPES";
            var reader = command.ExecuteReader();
            recipesList.Add(new Recipe()
            {
                Name = "asdfsdafjh"
            });
            while (reader.Read())
            {
                recipesList.Add(new Recipe()
                {
                    Name = "asdfsdafjh"
                });
            }

        }
        return recipesList;
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
            this.MasterPageFile = "~/MasterSingin.master";
            base.OnPreInit(e);
        }
        else
        {
            this.MasterPageFile = "~/MasterPage.master";
            base.OnPreInit(e);
        }

    }

    private void moreInfo_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string buttonId = button.ID;
        HttpCookie myCookie = new HttpCookie("addingId");
        myCookie.Value = buttonId;
        Response.Cookies.Add(myCookie);
        Response.Redirect("moreInfo.aspx");
    }


}