using BusinessLayer;
using System;
using System.Web.UI.WebControls;

namespace ShopProjectSV
{
    public partial class ProductPage : System.Web.UI.Page
    {

        LogHelper hlp = new LogHelper();
        ProductService prodserv = null;
        OrderService orderserv = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            orderserv = new OrderService();
            prodserv = new ProductService();
            if (IsPostBack == false)
            {
                FillProductGrid();
            }
            if (Session["CustomerNameSession"] != null)
            {
                string custname = Session["CustomerNameSession"].ToString();
                customernamelbl.Text = "and name " + custname.ToString();
            }
            if (Session["CustomerIDSession"] != null)
            {
                int customerid = Convert.ToInt32(Session["CustomerIDSession"]);
                customeridlbl.Text = "Create order for customer id : " + customerid.ToString();
            }
        }

        private void FillProductGrid()
        {
            ProductGridView.DataSource = prodserv.GetProduct();
            ProductGridView.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductGridView.PageIndex = e.NewPageIndex;
            FillProductGrid();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            prodserv.GetProduct();
            FillProductGrid();
        }

        protected void orderprodbtn_Click(object sender, EventArgs e)
        {
            int customerid = Convert.ToInt32(Session["CustomerIDSession"]);
            if (Session["CustomerIDSession"] != null)
            {
                customeridlbl.Text = customerid.ToString();
            }
            else
            {
                string nocustselected = "Nu customer selected for this order \n You can't create your order, please go back to <a href=\\Customers.aspx> Customers page </a> and select a customer";
                nocustomerselectederror.Text = nocustselected.ToString();
            }
            foreach (GridViewRow row in ProductGridView.Rows)
            {

                //Get quantity from textbox
                TextBox qty = row.Cells[6].FindControl("quantitytb") as TextBox;
                string q = qty.Text.ToString();
                int qtyorder = -1;
                int.TryParse(q, out qtyorder);
                //Get price
                string price = row.Cells[5].Text.ToString();
                decimal priceorder = -1;
                decimal.TryParse(price, out priceorder);
                //Get id for product
                string productid = row.Cells[1].Text.ToString();
                int prodid = -1;
                int.TryParse(productid, out prodid);
                bool t = true;



                if ((row.Cells[0].FindControl("prodchk") as CheckBox).Checked == t && qtyorder == 0)
                {// if product checked and no qty entered or zero
                    string multichkandnoqty = "Please enter quantity for each selected product";
                    multichkandnoqtylbl.Text = multichkandnoqty.ToString();
                }
                else if ((row.Cells[0].FindControl("prodchk") as CheckBox).Checked == t && qtyorder > 0)
                {// if product checked and no qty entered 1 message disabled
                    string multichkandnoqty = "";
                    multichkandnoqtylbl.Text = multichkandnoqty.ToString();
                }
                if (prodid != -1)
                {

                    if ((row.Cells[0].FindControl("prodchk") as CheckBox).Checked && Session["CustomerNameSession"] != null)
                    {
                        if (row.Cells[6].Controls[0].ToString() == "" || qtyorder <= 0)
                        {
                            string noqtyerror = "Please enter quantity 1 or higher";
                            noqtyerrorlbl.Text = noqtyerror.ToString();
                        }
                        else if (row.Cells[6].Controls[0].ToString() == "" || qtyorder <= 1)
                        {
                            string noqtyerror = "";
                            noqtyerrorlbl.Text = noqtyerror.ToString();
                        }
                        else
                        {
                            try
                            {
                                orderserv.AddCustomerOrder(customerid, prodid, qtyorder, priceorder);
                            }
                            catch (Exception ex)
                            {
                                hlp.LogError(ex);
                            }
                        }
                    }
                }

                // de adaugat
                // in sesiune daca nici un produs nu este selectat 

                if (((row.Cells[0].FindControl("prodchk") as CheckBox).Checked != t && Session["CustomerNameSession"] != null))
                {
                    string custname = Session["CustomerNameSession"].ToString();
                    customernamelbl.Text = custname.ToString();
                    string noqtyerror = "Please select a product for your customer " + customernamelbl.Text.ToString();
                    noproductselectedlbl.Text = noqtyerror.ToString();
                }
                //if (Session["CustomerNameSession"] == null)
                //{
                //    nocustomersessionlbl.Text = "You can't create your order, please go back to <a href=\\Customers.aspx> Customers page </a> and select a customer";
                //}
                if (((row.Cells[0].FindControl("prodchk") as CheckBox).Checked != t && qtyorder == 0))
                {
                    string noqtyandnochk = "Please enter a value higher than 1 and select at least a product";
                    zeroqtynochklbl.Text = noqtyandnochk.ToString();
                }
            }
        }
        protected void ProductGridView_DataBound(object sender, EventArgs e)
        {
            //Hide gridview ProductID & InventoryID
            GridView grview = (GridView)sender;
            if (grview.HeaderRow != null && grview.HeaderRow.Cells.Count > 0)
            {
                grview.HeaderRow.Cells[1].Visible = false;
            }
            foreach (GridViewRow row in ProductGridView.Rows)
            {
                row.Cells[1].Visible = false;
            }
        }
    }
}