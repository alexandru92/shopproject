<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="ShopProjectSV.Customers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" PageSize="10" AllowPaging="true" AutoGenerateColumns="false" EmptyDataText="Nu se vede nimic" ForeColor="#333333" GridLines="None" OnRowUpdating="GridView1_RowUpdating" OnPageIndexChanging="GridView1_PageIndexChanging">

                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"></asp:BoundField>
                    <asp:TemplateField ItemStyle-Width="100px" HeaderText="FirstName">
                        <EditItemTemplate>
                            <asp:Checkbox ID="chkFirstName" runat="server"
                                Text='<%# Eval("FirstName")%>'></asp:Checkbox>
                        </EditItemTemplate>
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
            <ul>
                 <li>FirstName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Width="147px"></asp:TextBox></li>
            </ul>
        </div>
    </form>
</body>
</html>
