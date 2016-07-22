<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="ShopProjectSV.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView AlternatingRowStyle-BackColor="Wheat" DataKeyNames="CustomerOrderID" PageSize="10" CellPadding="3" CellSpacing="1" ID="OrderGridView" AllowPaging="true" AutoGenerateColumns="false" EmptyDataText="Nu se vede nimic" ForeColor="#333333" GridLines="None" runat="server" OnPageIndexChanging="OrderGridView_PageIndexChanging">
                <Columns>
                 
                    <%--<asp:BoundField DataField="OrderID" HeaderText="CustomerOrderID"></asp:BoundField>--%>
                    <asp:BoundField DataField="Total" HeaderText="Total"></asp:BoundField>
                     <asp:BoundField DataField="customerorderlistdetails.FirstName" HeaderText="FirstName"></asp:BoundField>
                     <asp:BoundField DataField="customerorderlistdetails.LastName" HeaderText="LastName"></asp:BoundField>
                     <asp:BoundField DataField="customerorderlistdetails.PhoneNumber" HeaderText="PhoneNumber"></asp:BoundField>

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
        </div>
    </form>
</body>
</html>
