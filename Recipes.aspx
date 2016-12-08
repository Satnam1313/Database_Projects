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
                    <div class="col-xs-6 col-md-4">
						<div class="thumbnail">
							<div class="caption section">
								<h3><%# Eval("Name") %></h3>
								<h4>Cuisine: <%# Eval("Cuisine") %></h4>
								 <h4>Price:$<%# Eval("Price") %></h4>
								<p>
									<%# Eval("Description") %>
								</p>
								<div>
								    
								    <button class="btn btn-primary"  id="<%# Eval("Id") %>">Order</button>
<%--									<a class="btn btn-primary" href="../Orders/Order.aspx?f=<%# Eval("Id") %>">Order</a>--%>
								</div>
							</div>
						</div>
					</div>
                    
                </ItemTemplate>
            </asp:Repeater>
            <div id="dynamic" runat="server">
            </div>
        </div>
    </div>

    <asp:ObjectDataSource runat="server" ID="RecipesDataSource" TypeName="Recipe" SelectMethod="get_All"></asp:ObjectDataSource>
</asp:Content>

