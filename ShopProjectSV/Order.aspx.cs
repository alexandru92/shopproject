using BusinessLayer;
using System;
using System.Web.UI.WebControls;

namespace ShopProjectSV
{
    public partial class Order : System.Web.UI.Page
    {
        LogHelper hlp = new LogHelper();
        OrderService orderservice = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            orderservice = new OrderService();
            if (IsPostBack == false)
            {
                           FillOrderGrid();
            }
        }
        private void FillOrderGrid()
        {
            OrderGridView.DataSource = orderservice.custorder();
            OrderGridView.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            OrderGridView.PageIndex = e.NewPageIndex;
            FillOrderGrid();
        }
    }
}