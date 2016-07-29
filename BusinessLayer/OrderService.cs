using DataAcces.IDataAcces;
using System;
using DataAcces;
using DataContracts.Models;
using System.Collections.Generic;
using DataContracts.Models.IModels;
using DataContracts;

namespace BusinessLayer
{
    public class OrderService : IOrderRepository
    {
        LogHelper hlp = new LogHelper();
        public OrderRepository _orderRepository(OrderRepository orderrepo)
        {
            throw new NotImplementedException();
        }
        public List<CustomerOrder> Getcustorder(int CustomerOrderID)
        {
            List<CustomerOrder> custorder = new List<CustomerOrder>();
            OrderRepository orderrepo = new OrderRepository();
            try
            {
                custorder = orderrepo.getCustomerOrderbyid(CustomerOrderID);
            }
            catch (Exception ex)
            {
                hlp.LogError(ex);
            }
            return custorder;
        }

        public List<CustomerOrder> GetAllOrdersByCustomerID(int CustomerID)
        {
            List<CustomerOrder> custorderbycustomerid = new List<CustomerOrder>();
            CustomerRepository customerorderorderrepo = new CustomerRepository();
            try
            {
                custorderbycustomerid = customerorderorderrepo.getOrderByCustomerID(CustomerID);
            }
            catch (Exception ex)
            {
                hlp.LogError(ex);
            }
            return custorderbycustomerid;
        }

        public List<AllCustomerOrderDetail>AllCustomerOrderDetailByCustomerID(int CustomerID)
        {
            List<AllCustomerOrderDetail> allcustomerdetailbycustomerid = new List<AllCustomerOrderDetail>();
            OrderRepository orderrepo = new OrderRepository();
            try
            {
                allcustomerdetailbycustomerid = orderrepo.getAllCustomerOrderDetail(CustomerID);
            }
            catch (Exception ex)
            {
                hlp.LogError(ex);
            }
            return allcustomerdetailbycustomerid;
        }
        public void AddCustomerOrder(int customerID, int productID, int quantity, decimal price)
        {
            OrderDetail orderdetail = new OrderDetail();
            Customer cust = new Customer();
            OrderRepository orderrepo = new OrderRepository();
            try
            {
                orderrepo.AddOrder(orderdetail.ProductID= productID,cust.CustomerID= customerID, orderdetail.Quantity= quantity, orderdetail.Price= price);
            }
            catch (Exception ex)
            {
                hlp.LogError(ex);
            }
        }
    }
}
