using BusinessLayer;
using DataContracts.Models;
using System;
using System.Web.UI.WebControls;

namespace ShopProjectSV
{
    public partial class ProductPage : System.Web.UI.Page
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

        protected void AddProduct_Click(object sender, EventArgs e)
        {
            Product prod = new Product();
            //if (IsPostBack)
            //{
            //    prodnametb.Text = "";
            //    categorytb.Text = "";
            //    descriptiontb.Text = "";
            //    pricetb.Text = "";
            //}
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
    }
}