<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="ShopProjectSV.Inventory" %>

<!DOCTYPE html>
<link href="/Style/GridStyle.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="InventoryGridView" runat="server" AutoGenerateColumns="false" DataKeyNames="InventoryID" AlternatingRowStyle-BackColor="Wheat" CellPadding="3" CellSpacing="1" PageSize="10" AllowPaging="true" EmptyDataText="Nu se vede nimic" ForeColor="#333333" GridLines="None" OnPageIndexChanging="InventoryGridView_PageIndexChanging" OnDataBound="InventoryGridView_DataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="prodinventorychk" runat="server" />

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="InventoryID" HeaderText="InventoryID" SortExpression="InventoryID"></asp:BoundField>
                    <asp:BoundField DataField="ProductID"  HeaderText="ProductID" SortExpression="ProductID"></asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
                    <asp:BoundField DataField="prod.Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                    <asp:BoundField DataField="prod.Category" HeaderText="Category" SortExpression="Category"></asp:BoundField>
                    <asp:BoundField DataField="prod.Description" HeaderText="Description" SortExpression="Description"></asp:BoundField>
                    <asp:BoundField DataField="prod.Price" HeaderText="Price" SortExpression="Price"></asp:BoundField>
                    <asp:TemplateField HeaderText="Inventory">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="inventorytb"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

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
        <asp:Label ID="noinventorynocheck" runat="server" Text=""></asp:Label>
        <asp:Label ID="noproductchklbl" runat="server" Text=""></asp:Label>
        <asp:Button ID="inventorybtn" runat="server" Text="Add Inventory" OnClick="inventorybtn_Click" />

    </div>
    </form>
</body>
</html>
