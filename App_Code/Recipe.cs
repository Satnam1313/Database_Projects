using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for Recipe
/// </summary>
public class Recipe
{
    private static string connectionstring = WebConfigurationManager.ConnectionStrings["oracle"].ConnectionString;
    private static ICollection _allRecipes;

    #region Properties
    public string Name { get; set; }
    #endregion

    public static ICollection All
    {
        get
        {
            if (_allRecipes != null)
                return _allRecipes;
            else
                return GetRecipes();
        }
    }

    private static ICollection GetRecipes()
    {
        var recipesList = new List<Recipe>();
        using (var conn = new OracleConnection(connectionstring))
        {
            conn.Open();
            var command = conn.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from RECIPES";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                recipesList.Add(new Recipe()
                {
                    Name = reader["RECIPENAME"].ToString()
                });
            }
        }
        return _allRecipes = recipesList;
    }
}