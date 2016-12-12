<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Recipes.aspx.cs" Inherits="Recipes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <span class="  control-label navbar-text padd text-center " id="text" style="font-family: 'Pacifico', cursive; font-size: 36px" runat="server">Enjoy the Delicious Recipes <i class="fa fa-thumbs-o-up" aria-hidden="true"></i></span>
        <br />
    </div>
    <div class="container  padd" runat="server">
        <div class="row">
            <%--<asp:Repeater runat="server" DataSourceID="RecipesDataSource">
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
								   <a class="btn btn-primary" ID="button" href="Orders.aspx?f=<%# Eval("Id") %>">Order</a> 
								  
<%--									<a class="btn btn-primary" href="../Orders/Order.aspx?f=<%# Eval("Id") %>">Order</a>  data-target="#Order" data-toggle="modal"
								</div>
							</div>
						</div>
					</div>
                    
                </ItemTemplate>
            </asp:Repeater>
              <asp:ObjectDataSource runat="server" ID="RecipesDataSource" TypeName="Recipe" SelectMethod="get_All"></asp:ObjectDataSource>--%>
            <div id="dynamic" runat="server">
            </div>
        </div>
        
          <div class="modal fade" tabindex="-1" id="Order" role="dialog" aria-labelledby="modalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span class="pull-right" style="padding-top: 20px">&times;</span></button>
                    <h2 class="modal-title text-primary text-capitalize" id="modalLabelEdit">
                        Quantity <i class="fa fa-shopping-cart"></i>
                    </h2>
                </div>
                <div class="modal-body text">
                    <div class="container formtext text padd">
                        <div class="row">
                            <section class="col-sm-12 col-md-10">
                            <div class="form-horizontal">
                                <div class="form-group ">
                                    <asp:Label CssClass="col-sm-3 control-label " ID="RecipeName" runat="server" Text="Order Quantity"></asp:Label>
                                    <div class="col-sm-6 ">
                                        <asp:TextBox CssClass="form-control" placeholder="Quantity in numbers" ID="Recipebox" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                                </section>
                        </div>
                      </div>
                        <div class="modal-footer">
                            <asp:Button type="button" class="btn btn-success text-danger" runat="server" Text="Order it" OnClick="Order_recipe" />
                        </div>
                    
                </div>  
            </div>
        </div>
    </div>
        </div>
  
</asp:Content>

