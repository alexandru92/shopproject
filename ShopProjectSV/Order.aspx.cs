using BusinessLayer;
using System;
using System.Web.UI.WebControls;

namespace ShopProjectSV
{
    public partial class Order : System.Web.UI.Page
    {
        int CustomerOrderID;
        LogHelper hlp = new LogHelper();
        OrderService orderservice = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            orderservice = new OrderService();
            if (IsPostBack == false)
            {
                FillOrderGrid(CustomerOrderID);
            }
        }
        private void FillOrderGrid(int CustomerOrderID)
        {
            OrderGridView.DataSource = orderservice.Getcustorder(CustomerOrderID);
            OrderGridView.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            OrderGridView.PageIndex = e.NewPageIndex;
            FillOrderGrid(CustomerOrderID);
        }

        protected void OrderGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
            OrderGridView.PageIndex = e.NewPageIndex;
            FillOrderGrid(CustomerOrderID);
        }
    }
}