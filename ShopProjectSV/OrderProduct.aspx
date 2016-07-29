<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderProduct.aspx.cs" Inherits="ShopProjectSV.ProductPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="customeridlbl" runat="server" Text=""></asp:Label>
            <asp:Label ID="customernamelbl" runat="server" Text=""></asp:Label>
            <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="false" DataKeyNames="ProductID" AlternatingRowStyle-BackColor="Wheat" CellPadding="3" CellSpacing="1" PageSize="10" AllowPaging="true" EmptyDataText="Nu se vede nimic" ForeColor="#333333" GridLines="None" OnDataBound="ProductGridView_DataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="prodchk" runat="server" />

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID"></asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category"></asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"></asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"></asp:BoundField>
                    <asp:TemplateField HeaderText="Enter Quantity">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="quantitytb"></asp:TextBox>
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

            <asp:Button ID="orderprodbtn" runat="server" Text="Order" OnClick="orderprodbtn_Click" />
            <div>
                <asp:Label ID="noqtyerrorlbl" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="nocustomerselectederror" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="noproductselectedlbl" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="nocustomersessionlbl" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="zeroqtynochklbl" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="multichkandnoqtylbl" runat="server" Text=""></asp:Label>
                

                <%--<ul id="addlistcss">
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
            <br />--%>
            </div>
        </div>
    </form>
</body>
</html>
