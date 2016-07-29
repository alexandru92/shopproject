using BusinessLayer;
using DataContracts;
using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace ShopProjectSV
{

    public partial class Customers : System.Web.UI.Page
    {

        LogHelper hlp = new LogHelper();
        CustomerService customerserv = null;
        OrderService orderserv = null;
        Customer cust = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            orderserv = new OrderService();
            customerserv = new CustomerService();
            if (IsPostBack == false)
            {

                FillCustomerGrid();
            }
        }
        private void FillCustomerGrid()
        {
            CustomerGridView.DataSource = customerserv.GetCustomer();
            CustomerGridView.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CustomerGridView.PageIndex = e.NewPageIndex;
            FillCustomerGrid();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)CustomerGridView.Rows[e.RowIndex];
            customerserv.GetCustomer();
            FillCustomerGrid();
        }

        protected void AddCustomer_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer();
            cust.address = new Address();
            try
            {
                cust.FirstName = fnametb.Text;
                cust.LastName = lnametb.Text;
                cust.PhoneNumber = phonenumbertb.Text;
                cust.DateBirth = Convert.ToDateTime(datebirthtb.Text);
                cust.address.City = citytb.Text;
                cust.address.Street = streettb.Text;
                cust.address.Country = countrytb.Text;
                customerserv.AddCustomer(cust);
            }
            catch (Exception ex)
            {
                hlp.LogError(ex);
            }
            FillCustomerGrid();
        }

        protected void GetSelectedRecords(object sender, EventArgs e)
        {
            CustomerOrder custorder = new CustomerOrder();
            custorder.customerorderlistdetails = new Customer();
            foreach (GridViewRow row in CustomerGridView.Rows)
            {
                if ((row.Cells[0].FindControl("chk") as CheckBox).Checked)
                {
                    string value = CustomerGridView.DataKeys[row.RowIndex].Values[0].ToString();
                    int v = Convert.ToInt32(value);
                    gridviewSelectedCustomerRow.DataSource = orderserv.GetAllOrdersByCustomerID(v);
                    gridviewSelectedCustomerRow.DataBind();
                }
            }
        }

        protected void ViewOrderedProducts_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in CustomerGridView.Rows)
            {
                if ((row.Cells[0].FindControl("chk") as CheckBox).Checked)
                {
                    string value = CustomerGridView.DataKeys[row.RowIndex].Values[0].ToString();
                    int v = Convert.ToInt32(value);
                    gridvieworderedproducts.DataSource = orderserv.AllCustomerOrderDetailByCustomerID(v);
                    gridvieworderedproducts.DataBind();
                }
            }
        }

        protected void neworderbtn_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in CustomerGridView.Rows)
            {
                if ((row.Cells[0].FindControl("chk") as CheckBox).Checked)
                {
                    string value = CustomerGridView.DataKeys[row.RowIndex].Values[0].ToString();
                    int v = Convert.ToInt32(value);
                    Session["CustomerIDSession"] = v;
                    string fname = row.Cells[3].Text.ToString();
                    string lname = row.Cells[4].Text.ToString();
                    Session["CustomerNameSession"] = fname + " " + lname;
                }
            }
            Page.Response.Redirect("~/OrderProduct.aspx");
        }

        //protected void CustomerGridView_DataBound(object sender, EventArgs e)
        //{
        //    //Hide gridview CustomerID
        //    GridView grview = (GridView)sender;
        //    if (grview.HeaderRow != null && grview.HeaderRow.Cells.Count > 0)
        //    {
        //        grview.HeaderRow.Cells[2].Visible = false;
        //    }
        //    foreach (GridViewRow row in CustomerGridView.Rows)
        //    {
        //        row.Cells[2].Visible = false;
        //    }
        //}

    }
}








