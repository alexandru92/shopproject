using BusinessLayer;
using DataContracts.Models;
using System;
using System.Web.UI.WebControls;

namespace ShopProjectSV
{
    public partial class Order : System.Web.UI.Page
    {
        LogHelper hlp = new LogHelper();
        ProductService prodserv = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            prodserv = new ProductService();
            if (IsPostBack == false)
            {
                FillProductGrid();
            }
        }
        private void FillProductGrid()
        {
            ProductGridView.DataSource = prodserv.GetProduct();
            ProductGridView.DataBind();
        }
        protected void ProductGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductGridView.PageIndex = e.NewPageIndex;
            ProductGridView.DataBind();
        }
        protected void AddProduct_Click(object sender, EventArgs e)
        {
            Product prod = new Product();
            try
            {
                prod.Name = prodnametb.Text;
                prod.Category = categorytb.Text;
                prod.Description = descriptiontb.Text;
                prod.Price = Convert.ToInt32(pricetb.Text);
                prodserv.AddProduct(prod);
            }
            catch (Exception ex)
            {
                hlp.LogError(ex);
            }
            FillProductGrid();
        }

        protected void ProductGridView_DataBound(object sender, EventArgs e)
        {
            //Hide gridview ProductID & InventoryID
            GridView grview = (GridView)sender;
            if (grview.HeaderRow != null && grview.HeaderRow.Cells.Count > 0)
            {
                grview.HeaderRow.Cells[0].Visible = false;

            }
            foreach (GridViewRow row in ProductGridView.Rows)
            {
                row.Cells[0].Visible = false;
            }
        }
    }
}