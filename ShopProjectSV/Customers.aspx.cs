using BusinessLayer;
using BusinessLayer.IBusinessLayer;
using DataAcces;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopProjectSV
{

    public partial class Customers : System.Web.UI.Page, ICustomersService
    {
        Customer cust = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                FillCustomerGrid();

            }
        }

        private void FillCustomerGrid()
        {

            //GridView1.DataSource = getCustomerManager(custrepo); 
            ////CustomerGridView 
            //GridView1.DataSource
            //GridView1.DataBind();
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
            TextBox FirstName = (TextBox)row.Cells[0].Controls[0];
            if (FirstName != null)
            {
                Customer cust = new Customer();
                cust.FirstName = FirstName.Text;
            }
            FillCustomerGrid();
        }

        public CustomerService _customerservice(CustomerService customerservice)
        {
            throw new NotImplementedException();
        }
    }
}

