using BusinessLayer;
using BusinessLayer.IBusinessLayer;
using DataContracts;
using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ShopProjectSV
{

    public partial class Customers : System.Web.UI.Page
    { LogHelper hlp = new LogHelper();
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
            CustomerGridView.DataSource = customerserv.GetCustomer();
            CustomerGridView.DataBind();

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CustomerGridView.PageIndex = e.NewPageIndex;
            DataBind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)CustomerGridView.Rows[e.RowIndex];
            TableCellCollection cells = row.Cells;
            TextBox City = (TextBox)row.Cells[1].Controls[0];
            //if (FirstName != null)
            //{

            //}
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
            catch(Exception ex)
            {
                hlp.LogError(ex);
            }
            FillCustomerGrid();
        }
    }
}

