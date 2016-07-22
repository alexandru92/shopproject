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
        int OrderID;
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
        //private void FillCustomerGridDetails()
        //{
        //    gridviewSelectedCustomerRow.DataSource = orderserv.Getcustorder(OrderID);
        //    gridviewSelectedCustomerRow.DataBind();
        //}
        private void FillCustomerGrid()
        {
            
            CustomerGridView.DataSource = customerserv.GetCustomer();
            CustomerGridView.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //string pageId = string.Format("Page{0}", CustomerGridView.PageIndex);
            //bool[] selectedCheckboxes = new bool[CustomerGridView.PageSize];
            //for (int i = 0; i < CustomerGridView.Rows.Count; i++)
            //{
            //    TableCell cell = CustomerGridView.Rows[i].Cells[0];
            //    selectedCheckboxes[i] = (cell.FindControl("chk") as CheckBox).Checked;
            //}
            //ViewState[pageId] = selectedCheckboxes;
            CustomerGridView.PageIndex = e.NewPageIndex;
            FillCustomerGrid();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)CustomerGridView.Rows[e.RowIndex];
            //TableCellCollection cells = row.Cells;
            //TextBox City = (TextBox)row.Cells[1].Controls[0];
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
            //custorder.orderedproduct = new Product();
            ////1

            // DataTable dt = new DataTable();
            //dt.Columns.Add("QuantityOrdered");
            //dt.Columns.Add("custorderdetails.FirstName");
            //dt.Columns.Add("custorderdetails.LastName");
            //dt.Columns.Add("custorderdetails.PhoneNumber");
            //dt.Columns.Add("orderedproduct.Name");
            //dt.Columns.Add("orderedproduct.Price");
            //dt.Columns.Add("orderedproduct.Description");
            //dt.Columns.Add("orderedproduct.Category");

            foreach (GridViewRow row in CustomerGridView.Rows)
            {
                if ((row.Cells[1].FindControl("chk") as CheckBox).Checked)
                {
                    gridviewSelectedCustomerRow.DataSource = orderserv.Getcustorder(OrderID);
                    gridviewSelectedCustomerRow.DataBind();
                    //FillCustomerGridDetails();
                    //2
                    //DataRow dr = dt.NewRow();

                    //dr["QuantityOrdered"] = row.Cells[1].Text;
                    //dr["custorderdetails.FirstName"] = row.Cells[2].Text;
                    //dr["custorderdetails.LastName"] = row.Cells[3].Text;
                    //dr["custorderdetails.PhoneNumber"] = row.Cells[4].Text;
                    //dr["orderedproduct.Name"] = row.Cells[5].Text;
                    //dr["orderedproduct.Price"] = row.Cells[6].Text;
                    //dr["orderedproduct.Description"] = row.Cells[7].Text;
                    //dr["orderedproduct.Category"] = row.Cells[8].Text;
                    //dt.Rows.Add(dr);

                }
                //CheckBox chk = new CheckBox();
                //chk = sender as CheckBox;
                //chk = (CheckBox)CustomerGridView.FindControl("chk");
                //if (chk.Checked)
                //{


                //}
                //}
                //try
                //{
                //    foreach (GridViewRow row in CustomerGridView.Rows)
                //    {

                //        string str = CustomerGridView.Rows[0].Controls[0].ToString();
                //        string pageId = string.Format("Page{0}", CustomerGridView.PageIndex);
                //        bool[] selectedcheckboxes = ViewState[str] as bool[];
                //        if (selectedcheckboxes != null)
                //        {
                //            for (int i = 0; i < CustomerGridView.Rows.Count; i++)
                //            {
                //                TableCell cell = CustomerGridView.Rows[i].Cells[0];
                //                (cell.FindControl("chk") as CheckBox).Checked = selectedcheckboxes[i];
                //            }
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    hlp.LogError(ex);
                //}
            }
        }

        protected void CustomerGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}



