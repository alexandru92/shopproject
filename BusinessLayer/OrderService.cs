using DataAcces.IDataAcces;
using System;
using DataAcces;
using DataContracts.Models;
using System.Collections.Generic;

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
    }
}
