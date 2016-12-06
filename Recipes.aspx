<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Recipes.aspx.cs" Inherits="Recipes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <span class="  control-label navbar-text padd text-center " id="text" style="font-family: 'Pacifico', cursive; font-size: 36px" runat="server">Enjoy the Delicious Recipes <i class="fa fa-thumbs-o-up" aria-hidden="true"></i></span>
        <br />
    </div>
    <div class="container  padd" runat="server">
        <div class="row">
            <asp:Repeater runat="server" DataSourceID="RecipesDataSource">
                <ItemTemplate>
                    <h4><%# Eval("Name") %></h4>
                </ItemTemplate>
            </asp:Repeater>
            <div id="dynamic" runat="server">
            </div>
        </div>
    </div>

    <asp:ObjectDataSource runat="server" ID="RecipesDataSource" TypeName="Recipe" SelectMethod="get_All"></asp:ObjectDataSource>
</asp:Content>

