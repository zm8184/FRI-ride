<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="AddRide.aspx.cs" Inherits="Account_AddRide" Async="true" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   
    <h2>Add ride</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
 
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Driver_User_Name" CssClass="col-md-2 control-label">Driver</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Driver_User_Name" CssClass="form-control" disabled="disabled"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Driver_User_Name"
                    CssClass="text-danger" ErrorMessage="The user name field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Start_location" CssClass="col-md-2 control-label">Start location</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Start_location" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Start_location"
                    CssClass="text-danger" ErrorMessage="The start location field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="DateRide" CssClass="col-md-2 control-label">Time</asp:Label>
            <div class="col-md-10">
                <input type="datetime-local" name="Date" id="DateRide" runat="server"/>
            </div>
        </div>


        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="AddRide_Click" Text="Add ride" CssClass="btn btn-default"  async defer/>
            </div>
        </div>
        <input type="button" id="routebtn" value="route" />
          <div id="map-canvas" style="height:800px;width: 800px;margin: 0px;padding: 0px"></div>      
    </div>
    <script src="../Scripts/maps.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=APIKEY&callback=mapLocation&libraries=places" async defer></script>
</asp:Content>
