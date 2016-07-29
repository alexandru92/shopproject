<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ShopProjectSV.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView AlternatingRowStyle-BackColor="Wheat" DataKeyNames="ProductID" PageSize="10" CellPadding="3" CellSpacing="1" ID="ProductGridView" AllowPaging="true" AutoGenerateColumns="false" EmptyDataText="Nu se vede nimic" ForeColor="#333333" GridLines="None" runat="server" OnPageIndexChanging="ProductGridView_PageIndexChanging" OnDataBound="ProductGridView_DataBound">
                <Columns>
                 
                    <%--<asp:BoundField DataField="OrderID" HeaderText="CustomerOrderID"></asp:BoundField>--%>
                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID"></asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category"></asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"></asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"></asp:BoundField>

                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>
                <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
                <RowStyle BackColor="#EFF3FB"></RowStyle>
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>
                <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>
                <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>
                <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
            </asp:GridView>
            <div>
                <asp:Label ID="noqtyerrorlbl" runat="server" Text=""></asp:Label></div>
            <ul id="addlistcss">
                <li>Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="prodnametb" runat="server" Width="147px" AutoCompleteType="Disabled"></asp:TextBox></li>
                <li>Category &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="categorytb" runat="server" Width="147px" AutoCompleteType="Disabled"></asp:TextBox></li>
                <li>Description &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="descriptiontb" runat="server" Width="147px" AutoCompleteType="Disabled"></asp:TextBox></li>
                <li>Price &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:TextBox ID="pricetb" runat="server" Width="147px" AutoCompleteType="Disabled"></asp:TextBox></li>
            </ul>
            <br />
            <asp:Button ID="AddProduct" runat="server" Text="Add Product" OnClick="AddProduct_Click" />
            <br />
        </div>
        
    </form>
</body>
</html>
