using BusinessLayer;
using DataAcces;
using System;
using System.Web.UI.WebControls;

namespace ShopProjectSV
{
    public partial class Inventory : System.Web.UI.Page
    {
        LogHelper hlp = new LogHelper();
        ProductService prodservice = new ProductService();
        InventoryService inventoryservice = new InventoryService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                FillInventoryGrid();
            }
        }
        protected void FillInventoryGrid()

        {
            prodservice.GetProduct();
            InventoryGridView.DataBind();
            InventoryGridView.DataSource = inventoryservice.Getcustorder();
            InventoryGridView.DataBind();
        }

        protected void InventoryGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            InventoryGridView.PageIndex = e.NewPageIndex;
            InventoryGridView.DataBind();
        }

        protected void InventoryGridView_DataBound(object sender, EventArgs e)
        {
            //Hide gridview ProductID & InventoryID
            GridView grview = (GridView)sender;
            if (grview.HeaderRow != null && grview.HeaderRow.Cells.Count > 0)
            {
                grview.HeaderRow.Cells[1].Visible = false;
                grview.HeaderRow.Cells[2].Visible = false;
            }
            foreach (GridViewRow row in InventoryGridView.Rows)
            {
                row.Cells[1].Visible = false;
                row.Cells[2].Visible = false;
            }
        }

        protected void inventorybtn_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in InventoryGridView.Rows)
            {// get value from quantity textbox
                TextBox qtytb = row.Cells[7].FindControl("inventorytb") as TextBox;
                string q = qtytb.Text.ToString();
                int qtyinventory = -1;
                int.TryParse(q, out qtyinventory);
                // get product id for inventory
                string productid = row.Cells[2].Text.ToString();
                int prodid = -1;
                int.TryParse(productid, out prodid);
                bool check = true;
                //if ((row.Cells[0].FindControl("prodinventorychk") as CheckBox).Checked != check && qtyinventory <= 0)
                //{
                //    string errmsg = "Please select a product and specify inventory minimum 1";
                //    noinventorynocheck.Text = errmsg.ToString();
                //}
                //else if ((row.Cells[0].FindControl("prodinventorychk") as CheckBox).Checked == check && qtyinventory >= 1)
                //{
                //    string errmsg = "";
                //    noinventorynocheck.Text = errmsg.ToString();
                //}
                ////if ((row.Cells[0].FindControl("prodinventorychk") as CheckBox).Checked != check && qtyinventory >= 1)
                ////{
                ////    string errmsg = "Please enter inventory minimum 1";
                ////    noinventorynocheck.Text = errmsg.ToString();
                ////}
                if ((row.Cells[0].FindControl("prodinventorychk") as CheckBox).Checked == check && qtyinventory >= 1)
                {
                    try
                    {
                        InventoryRepository invrepo = new InventoryRepository();
                        DataContracts.Models.Inventory inv = new DataContracts.Models.Inventory();
                        inv.ProductID = prodid;
                        inv.Quantity = qtyinventory;
                        inventoryservice.AddInventory(inv);/* inventoryservice.AddInventory(prodid, qtyinventory);*/

                    }
                    catch (Exception ex)
                    {
                        hlp.LogError(ex);
                    }
                    string errmsg = "Inventory added";
                    noinventorynocheck.Text = errmsg.ToString();

                }

                else if ((row.Cells[0].FindControl("prodinventorychk") as CheckBox).Checked != check && qtyinventory >= 0)
                {
                    string errmsg = "Please select a product and add inventory minimum 1";
                    noinventorynocheck.Text = errmsg.ToString();
                }

            }

        }
    }
}