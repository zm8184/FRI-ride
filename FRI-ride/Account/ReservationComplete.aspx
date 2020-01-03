<%@ Page Title="Reservation Complete" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ReservationComplete.aspx.cs" Inherits="Account_ReservationComplete"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="height: 44px">Reservation Complete</h2>


    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <div class="form-group">
            <asp:Label runat="server" ID="Driver_User_Name" CssClass="col-md-2 control-label" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Larger">Driver:</asp:Label>
            <asp:TextBox ID="driver" runat="server" Height="22px" Width="1487px" Enabled="False"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label runat="server" ID="Label3" CssClass="col-md-2 control-label" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Larger">Phone number:</asp:Label>
            <asp:TextBox ID="phone_number" runat="server" Height="22px" Width="1487px" Enabled="False"></asp:TextBox>
            </div>
            
        

        <div class="form-group">
            <asp:Label runat="server" ID="Label1" CssClass="col-md-2 control-label" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Larger">Car:</asp:Label>
            
        
            <asp:TextBox ID="car" runat="server" Height="25px" Width="1512px" Enabled="False"></asp:TextBox>
            </div>
        <div class="form-group">
            <asp:Label runat="server" ID="Label2" CssClass="col-md-2 control-label" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Larger">Time:</asp:Label>
            
           
            <asp:TextBox ID="time" runat="server" Height="24px" Width="1492px" Enabled="False"></asp:TextBox>
            </div>
           
        

        <div class="form-group">
            <asp:Label runat="server" ID="Label4" CssClass="col-md-2 control-label" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Larger">Location:</asp:Label>
            
           
            <asp:TextBox ID="lokacija" runat="server" Height="24px" Width="1492px" Enabled="False"></asp:TextBox>
            </div>
           
        </div>


        
    </div>
    
</asp:Content>