<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Add" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container formtext text padd">
    <div class="row">
        <section class="col-sm-12">
    <div class="form-horizontal">
   <div class="form-group ">
       <asp:Label CssClass="col-sm-3 control-label " ID="RecipeName" runat="server" Text="Recipe Name"></asp:Label>
      <div class="col-sm-6 ">
        <asp:TextBox CssClass="form-control " placeholder="Recipe Name" ID="Recipebox" runat="server" ></asp:TextBox>
    </div><span class="text-primary">*</span><asp:RequiredFieldValidator ID="RecipeNameValidator" ControlToValidate="Recipebox" runat="server" ErrorMessage="Please fill Recipe Name"  Display="None" CssClass="text-primary"></asp:RequiredFieldValidator></div></div>
           
            <div class="form-horizontal">
             <div class="form-group ">
                 <asp:Label CssClass="col-sm-3 control-label " ID="Category" runat="server" Text="Category"></asp:Label> 
                 <div class="col-sm-6"><asp:DropDownList CssClass="dropdown form-control text" ID="CategoryList" runat="server">
                <asp:ListItem>Vegeterian</asp:ListItem>
                <asp:ListItem>Non-Veg</asp:ListItem>
            </asp:DropDownList>
                     </div>
      </div>
        </div>
               <div class="form-horizontal">
   <div class="form-group ">
       <asp:Label CssClass="col-sm-3 control-label " ID="CookingTime" runat="server" Text="Cooking Time"></asp:Label>
      <div class="col-sm-6 ">
        <asp:TextBox CssClass="form-control" placeholder="Enter the cooking time in minutes"  ID="CookingTimeBox" runat="server"></asp:TextBox> 
      </div><span class="text-primary">*</span><asp:RequiredFieldValidator ID="CookingBoxValidator" ControlToValidate="CookingTimeBox" runat="server" ErrorMessage="Please fill cooking time of Recipe"  Display="None" CssClass="text-primary"></asp:RequiredFieldValidator><asp:RangeValidator ControlToValidate="CookingTimeBox" ID="TimeRangeValidator" runat="server" ErrorMessage="Time should be positive number" MinimumValue="1" MaximumValue="99999" Display="None" Type="Integer" SetFocusOnError="True"  CssClass="text-primary"></asp:RangeValidator></div></div>
        <div class="form-horizontal">
             <div class="form-group ">
                 <asp:Label CssClass="col-sm-3 control-label " ID="Cuisine" runat="server" Text="Cuisine"></asp:Label> 
                 <div class="col-sm-6">
                     <asp:DropDownList CssClass="dropdown  form-control  text" ID="CuisineList" runat="server">
                         <asp:ListItem>Snack</asp:ListItem>
                         <asp:ListItem>Meal</asp:ListItem>
                         <asp:ListItem>Dessert</asp:ListItem>
                         <asp:ListItem>Appetizers</asp:ListItem>
                     </asp:DropDownList>

  </div>
      </div>
        </div>
             <div class="form-horizontal">
   <div class="form-group ">
      
        <div class="col-sm-9 col-sm-offset-3"><asp:CheckBox CssClass="control-label"  ID="Private" runat="server" /><asp:Label CssClass="" ID="PrivateLabel" runat="server" Text="Mark as private"></asp:Label>
      </div></div></div>
            <div class="form-horizontal">
   <div class="form-group ">
       <asp:Label CssClass="col-sm-3 control-label " ID="RecipeDescription" runat="server" Text="Recipe Description"></asp:Label>
      <div class="col-sm-6 ">
        <asp:TextBox ID="Steps" CssClass="form-control" placeholder="Write a small description for your recipe" runat="server" TextMode="MultiLine"></asp:TextBox>
      </div><span class="text-primary">*</span><asp:RequiredFieldValidator ID="DescriptionValidator" ControlToValidate="Steps" runat="server" ErrorMessage="Please write small description of Recipe"  Display="None" CssClass="text-primary"></asp:RequiredFieldValidator></div></div>
               <div class="form-horizontal">
   <div class="form-group ">
       <asp:Label ID="RecipeSteps" CssClass="col-sm-3 control-label" runat="server" Text="Recipe Steps">
          </asp:Label>
      <div class="col-sm-6 ">
         <asp:TextBox ID="RecipeStep" placeholder="Write the steps in well organised manner" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
      </div><span class="text-primary">*</span><asp:RequiredFieldValidator ID="StepsValidator" ControlToValidate="Recipebox" runat="server" ErrorMessage="Please write steps of Recipe"  Display="None" CssClass="text-primary"></asp:RequiredFieldValidator></div></div>
         
            <div class="col-sm-9 btn-toolbar ">
                <asp:Button  class="btn btn-warning pull-right Cancel" id="Cancel" type="reset" value="Cancel" Text="Cancel" runat="server" />&nbsp; <asp:Button class="btn btn-success pull-right Submit" id="Submit" type="submit" Text="Submit"  runat="server" OnClick="Submit_Click"  />
            </div>
  
           
                
                
        </section>  <mark class="text-primary"><asp:ValidationSummary ID="Summary" runat="server" HeaderText="Please fullfill following requirements"/></mark>
        <p ID="dynamic" style="font-family: 'Pacifico', cursive; font-size: 25px" runat="server"></p>
   </div></div>
</asp:Content>

