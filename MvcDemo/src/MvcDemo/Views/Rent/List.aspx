<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcDemo.Models.RentalProperty>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="rentalPropertyList">
       <% foreach (var item in Model) {
            Html.RenderPartial("PropertyPartial", item); 
        } %>
    </div>
    
    <%= Html.ActionLink("Create New", "Create") %>
</asp:Content>

