<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcDemo.Models.RentalProperty>" %>

<div class="rentalProperty">
    <table cellpadding="0" cellspacing="0" border="0" class="rentalProperty">
        <col style="width: 180px;" />
        <col />
        <col style="width: 150px;" />
        <tr class="header">
            <td class="suburb">
                <%= Html.Encode(Model.AddressSuburb) %>
            </td>
            <td class="rent">
                $<%= Html.Encode(String.Format("{0:F}", Model.Rent)) %>
            </td>
            <td class="rooms">
                <img alt="bedrooms" src="../../Images/bed.png" />
                <%= Html.Encode(Model.NumberBedrooms) %>
                &nbsp;&nbsp;
                <img alt="bathrooms" src="../../Images/bath.png" />
                <%= Html.Encode(Model.NumberBathrooms) %>
                &nbsp;&nbsp;
                <img alt="car spaces" src="../../Images/car.png" />
                <%= Html.Encode(Model.NumberCarSpaces) %>
            </td>
        </tr>
        <tr class="property-details">
            <td class="property-details-column1">
                <img alt="image1" src="<%= Html.Encode(Model.ImageUrl1) %>" /><br />
                <img alt="image2" src="<%= Html.Encode(Model.ImageUrl2) %>" />
            </td>
            <td class="property-details-column2">
                <span class="property-address-line">
                    <%= Html.Encode(Model.AddressStreet) %>&nbsp;
                    <%= Html.Encode(Model.AddressSuburb) %>
                </span><br /><br />
                <span class="property-bold">
                    <%= Html.Encode(Model.Summary) %>
                </span><br />
                <span>
                    <%= Html.Encode(Model.Description) %>
                </span>
            </td>
            
            <td class="property-details-column3">
                <span class="property-bold">Contact</span><br />
                <span><%= Html.Encode(Model.Contact) %></span><br /><br />
                <span class="property-bold">Phone</span><br />
                <span><%= Html.Encode(Model.ContactPhone) %></span>
            </td>
        </tr>
    </table>
</div>
