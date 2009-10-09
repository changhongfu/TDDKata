<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcDemo.Models.RentalProperty>" %>
<%@ Import Namespace="MvcDemo.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function flashit(context) {
            var selector = '#' + context.get_updateTarget().id + ' :first';
            $(selector).hide().fadeIn('slow');
            $(selector).pulse({
                borderColors: ['red', 'yellow'],
                speed: 500,
                duration: 5050
            });
        }
    </script>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Ajax.BeginForm(new AjaxOptions { InsertionMode = InsertionMode.InsertBefore, UpdateTargetId = "propertyTable", OnSuccess = "flashit" }))
       {%>
        <fieldset>
            <legend>Add New Property</legend>
            <table>
                <tr>
                    <td><label for="Rent">Rent:</label></td>
                    <td>
                        <%= Html.TextBox("Rent") %>
                        <%= Html.ValidationMessage("Rent", "*") %>
                    </td>
                    
                    <td><label for="NumberBedrooms">Bedrooms:</label></td>
                    <td>
                        <%= Html.TextBox("NumberBedrooms") %>
                        <%= Html.ValidationMessage("NumberBedrooms", "*") %>
                    </td>
                </tr>
                <tr>
                    <td><label for="AddressStreet">Street:</label></td>
                    <td>
                        <%= Html.TextBox("AddressStreet") %>
                        <%= Html.ValidationMessage("AddressStreet", "*") %>
                    </td>
                    <td><label for="NumberBathrooms">Bathrooms:</label></td>
                    <td>
                        <%= Html.TextBox("NumberBathrooms") %>
                        <%= Html.ValidationMessage("NumberBathrooms", "*") %>
                    </td>
                </tr>
                <tr>
                    <td><label for="AddressSuburb">Suburb:</label></td>
                    <td>
                        <%= Html.TextBox("AddressSuburb") %>
                        <%= Html.ValidationMessage("AddressSuburb", "*") %>
                    </td>
                    
                    <td><label for="NumberCarSpaces">Car Spaces:</label></td>
                    <td>
                        <%= Html.TextBox("NumberCarSpaces") %>
                        <%= Html.ValidationMessage("NumberCarSpaces", "*") %>
                    </td>
                </tr>
                <tr>
                    <td><label for="Summary">Summary:</label></td>
                    <td colspan="3">
                        <%= Html.TextBox("Summary") %>
                        <%= Html.ValidationMessage("Summary", "*") %>
                    </td>
                </tr>
                <tr>
                    <td><label for="Description">Description:</label></td>
                    <td colspan="3">
                        <%= Html.TextArea("Description") %>
                        <%= Html.ValidationMessage("Description", "*") %>
                    </td>
                </tr>
                <tr>
                    <td><label for="Contact">Contact:</label></td>
                    <td>
                        <%= Html.TextBox("Contact") %>
                        <%= Html.ValidationMessage("Contact", "*") %>
                    </td>
                    <td><label for="ImageUrl1">Image1:</label></td>
                    <td>
                        <%= Html.TextBox("ImageUrl1") %>
                        <%= Html.ValidationMessage("ImageUrl1", "*") %>
                    </td>
                </tr>
                <tr>
                    <td><label for="ContactPhone">Phone:</label></td>
                    <td>
                        <%= Html.TextBox("ContactPhone") %>
                        <%= Html.ValidationMessage("ContactPhone", "*") %>
                    </td>
                     <td> <label for="ImageUrl2">Image2:</label></td>
                    <td>
                        <%= Html.TextBox("ImageUrl2") %>
                        <%= Html.ValidationMessage("ImageUrl2", "*") %>
                    </td>
                </tr>
            </table>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>
    <% } %>
    
    
    <div id="propertyTable" class="rentalPropertyList">
         <% foreach (var item in (RentalProperty[])ViewData["Properties"]) {
            Html.RenderPartial("PropertyPartial", item); 
         } %>
    </div>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

