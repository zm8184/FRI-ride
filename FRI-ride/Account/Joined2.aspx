<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Joined2.aspx.cs" Inherits="Account_Rides" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <div class="form-group">
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" Width="823px">
                    <ItemTemplate>
                        name:
                        <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                        <br />
                        surname:
                        <asp:Label ID="surnameLabel" runat="server" Text='<%# Eval("surname") %>' />
                        <br />
                        number:
                        <asp:Label ID="numberLabel" runat="server" Text='<%# Eval("number") %>' />
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:fri-rideConnectionString3 %>"></asp:SqlDataSource>
            
            </div>     
        </div>
    </div>
</asp:Content> 