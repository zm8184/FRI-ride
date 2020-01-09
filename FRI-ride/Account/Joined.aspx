<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Joined.aspx.cs" Inherits="Account_Rides" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <div class="form-group">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:fri-rideConnectionString3 %>"></asp:SqlDataSource>
                <h2>My rides.</h2>    
                <asp:DataList ID="DataList1" runat="server" CellPadding="10" DataSourceID="SqlDataSource1" ForeColor="#333333" Width="1093px" OnSelectedIndexChanged="DataList_SelectedIndexChanged" DataKeyField="id_oglas" onitemcommand="DataList_projects_ItemCommand" CellSpacing="5">
                    <AlternatingItemStyle BackColor="White" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="#E3EAEB" />
                        <ItemTemplate>
                        <strong>Location:</strong>
                        <asp:Label ID="locationLabel" runat="server" Text='<%# Eval("location") %>' />
                        <br />
                        <strong>Date and time:</strong>
                        <asp:Label ID="dateLabel" runat="server" Text='<%# Eval("date") %>' />
                        <br />
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CommandName="getID" Font-Bold="True">View details</asp:LinkButton>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                
            
            </div>     
        </div>
    </div>
</asp:Content> 