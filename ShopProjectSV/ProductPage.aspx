﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="ShopProjectSV.ProductPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="false" DataKeyNames="ProductID" AlternatingRowStyle-BackColor="Wheat"  CellPadding="3" CellSpacing="1" PageSize="10" AllowPaging="true" EmptyDataText="Nu se vede nimic" ForeColor="#333333" GridLines="None">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category"></asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"></asp:BoundField>
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"></asp:BoundField>
            </Columns>

        </asp:GridView>
        <ul id="addlistcss">
                <li>Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="prodnametb" runat="server" Width="147px"></asp:TextBox></li>
                <li>Category &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="categorytb" runat="server" Width="147px"></asp:TextBox></li>
                <li>Description &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="descriptiontb" runat="server" Width="147px"></asp:TextBox></li>
                <li>Price &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:TextBox ID="pricetb" runat="server" Width="147px"></asp:TextBox></li>
            </ul>
            <br />
            <asp:Button ID="AddProduct" runat="server" Text="Add Product" OnClick="AddProduct_Click"  />
            <br />
    </div>
    </form>
</body>
</html>