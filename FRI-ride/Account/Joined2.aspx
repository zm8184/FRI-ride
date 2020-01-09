<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Joined2.aspx.cs" Inherits="Account_Rides" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <div class="form-group">
                <h2>Detailes of ride.</h2>
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" Width="823px">
                    
                    <AlternatingItemStyle BackColor="White" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="#E3EAEB" />
                    <ItemTemplate>
                        <strong>Name:</strong>
                        <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                        <br />
                        <strong>Surname:</strong>
                        <asp:Label ID="surnameLabel" runat="server" Text='<%# Eval("surname") %>' />
                        <br />
                        <strong>Number:</strong>
                        <asp:Label ID="numberLabel" runat="server" Text='<%# Eval("number") %>' />
                        <br />
                        <strong>Location:</strong>
                        <asp:Label ID="locationLabel" runat="server" Text='<%# Eval("location") %>' />
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:fri-rideConnectionString3 %>"></asp:SqlDataSource>
            
            </div>     
        </div>
    </div>
</asp:Content> 