using BusinessLayer;
using BusinessLayer.IBusinessLayer;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ShopProjectSV
{

    public partial class Customers : System.Web.UI.Page
    {
        CustomerService customerserv = null;
        Customer cust = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            customerserv = new CustomerService();
            if (IsPostBack == false)
            {
                FillCustomerGrid();
            }
        }
        //public CustomerService _customerservice(CustomerService customerservice)
        //{
        //    customerserv = _customerservice(customerservice);
        //}

        private void FillCustomerGrid()
        {
            GridView1.DataSource = customerserv.GetCustomer();
            GridView1.DataBind();

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DataBind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            TableCellCollection cells = row.Cells;
            TextBox City = (TextBox)row.Cells[1].Controls[0];
            //if (FirstName != null)
            //{

            //}
            customerserv.GetCustomer();
            FillCustomerGrid();
        }

    }
}

