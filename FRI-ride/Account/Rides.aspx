<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Rides.aspx.cs" Inherits="Account_Rides" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">


<html>
<head>
    <title>Rides</title>
</head>
<body>
    
</body>
</html>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FRI-rideConnectionString %>" SelectCommand="SELECT oglas.id_oglas, uporabnik.username AS Username, uporabnik.tel_stevilka AS Number, oglas.lokacija AS Location, oglas.cas_datum AS Time FROM uporabnik INNER JOIN voznik ON uporabnik.id_uporabnik = voznik.id_uporabnik INNER JOIN oglas ON oglas.id_voznik = voznik.id_voznik ORDER BY Time DESC"></asp:SqlDataSource>
    <h2>Rides.</h2>
    <asp:DataList ID="DataList1" runat="server" CellPadding="10" DataSourceID="SqlDataSource1" ForeColor="#333333" Width="1093px" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" DataKeyField="id_oglas" onitemcommand="DataList_projects_ItemCommand" CellSpacing="5">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#E3EAEB" />
        <ItemTemplate>
            <asp:Label ID="id_oglasLabel" runat="server" Text='<%# Eval("id_oglas") %>' Visible="False" AssociatedControlID='<%# Eval("id_oglas") %>' />
            <br />
            Username:
            <asp:Label ID="UsernameLabel" runat="server" Text='<%# Eval("Username") %>' />
            <br />
            Number:
            <asp:Label ID="NumberLabel" runat="server" Text='<%# Eval("Number") %>' />
            <br />
            Location:
            <asp:Label ID="LocationLabel" runat="server" Text='<%# Eval("Location") %>' />
            <br />
            Time:
            <asp:Label ID="TimeLabel" runat="server" Text='<%# Eval("Time") %>' />
            <br />
            <br />
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CommandName="getID" Font-Bold="True">Join Ride</asp:LinkButton>
                <br />
        </ItemTemplate>
        <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>
    <br /><a href="AddRide" class="button">Not the one you are looking for. Add one yourself (click here)</a>

</asp:Content> 