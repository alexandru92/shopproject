﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="ShopProjectSV.Customers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Grid</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="CustomerGridView" AlternatingRowStyle-BackColor="Wheat" DataKeyNames="CustomerID" CellPadding="3" CellSpacing="1" runat="server" PageSize="10" AllowPaging="true" AutoGenerateColumns="false" EmptyDataText="Nu se vede nimic" ForeColor="#333333" GridLines="None" OnRowUpdating="GridView1_RowUpdating" OnPageIndexChanging="GridView1_PageIndexChanging">

                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="chk" OnCheckedChanged="GetSelectedRecords" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCustomerID" Text='<%#Eval("CustomerID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID"></asp:BoundField>
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"></asp:BoundField>
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName"></asp:BoundField>
                    <asp:BoundField DataField="DateBirth" HeaderText="DateBirth" SortExpression="DateBirth" DataFormatString="{0:MM/dd/yyyy}"></asp:BoundField>
                    <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber"></asp:BoundField>
                    <asp:BoundField DataField="address.City" HeaderText="City" SortExpression="City"></asp:BoundField>
                    <asp:BoundField DataField="address.Street" HeaderText="Street" SortExpression="Street"></asp:BoundField>
                    <asp:BoundField DataField="address.Country" HeaderText="Country" SortExpression="Country"></asp:BoundField>
                    <asp:ButtonField HeaderText="Customer details" Text="Details" />
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

           <asp:Button runat="server" ID="getSelectedDetailsbtn" Text="Get selected row details" OnClick="GetSelectedRecords" />
            <asp:Button runat="server" ID="vieworderedproducts" Text="View Ordered products" OnClick="ViewOrderedProducts_Click" />
            <asp:Button  runat="server" Text="New Order" ID="neworderbtn" OnClick="neworderbtn_Click"/>
            <asp:GridView ID="gridviewSelectedCustomerRow" runat="server" HeaderStyle-BackColor="Tomato" HeaderStyle-ForeColor="Wheat" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Total" HeaderText="Total"></asp:BoundField>
                    <asp:BoundField DataField="customerorderlistdetails.FirstName" HeaderText="FirstName"></asp:BoundField>
                    <asp:BoundField DataField="customerorderlistdetails.LastName" HeaderText="LastName"></asp:BoundField>
                    <asp:BoundField DataField="customerorderlistdetails.PhoneNumber" HeaderText="PhoneNumber"></asp:BoundField>
                </Columns>

            </asp:GridView>
            <asp:GridView ID="gridvieworderedproducts" runat="server" HeaderStyle-BackColor="Tomato" HeaderStyle-ForeColor="Wheat" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="orderdetail.Quantity" HeaderText="Quantity ordered" />
                   <%-- <asp:BoundField DataField="orderdetail.Price" HeaderText="Order Price" />--%>
                    <asp:BoundField DataField="customerorderedproduct.Name" HeaderText="Product Name" />
                    <asp:BoundField DataField="customerorderedproduct.Description" HeaderText="Product Description" />
                    <asp:BoundField DataField="customerorderedproduct.Category" HeaderText="Product Category" />
                    <asp:BoundField DataField="customerorderedproduct.Price" HeaderText="Product Price" />
                    <asp:BoundField DataField="customerorder.Total" HeaderText="Total"></asp:BoundField>
                    <asp:BoundField DataField="customerorderlistdetails.FirstName" HeaderText="FirstName"></asp:BoundField>
                    <asp:BoundField DataField="customerorderlistdetails.LastName" HeaderText="LastName"></asp:BoundField>
                    <asp:BoundField DataField="customerorderlistdetails.PhoneNumber" HeaderText="PhoneNumber"></asp:BoundField>

                </Columns>
            </asp:GridView>

            <ul id="addlistcss">
                <li>First name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="fnametb" runat="server" Width="147px"></asp:TextBox></li>
                <li>Last name &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="lnametb" runat="server" Width="147px"></asp:TextBox></li>
                <li>Date of birth&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="datebirthtb" runat="server" Width="147px"></asp:TextBox></li>
                <li>Phone number&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="phonenumbertb" runat="server" Width="147px"></asp:TextBox></li>
                <li>City&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="citytb" runat="server" Width="147px"></asp:TextBox></li>
                <li>Street &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="streettb" runat="server" Width="147px" Style="margin-left: 0px"></asp:TextBox></li>
                <li>Country&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="countrytb" runat="server" Width="147px" Style="margin-left: 0px"></asp:TextBox></li>

            </ul>
            <br />
            <asp:Button ID="AddCustomer" runat="server" Text="Add Customer" OnClick="AddCustomer_Click" />
            <br />


        </div>
    </form>
</body>
</html>
