using DataAcces.IDataAcces;
using System;
using DataAcces;
using DataContracts.Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class OrderService : IOrderRepository
    {
        CustomerOrder order = new CustomerOrder();
        LogHelper hlp = new LogHelper();
        public OrderRepository _orderRepository(OrderRepository orderrepo)
        {
            throw new NotImplementedException();
        }
        public List<CustomerOrder> custorder()
        {
            OrderRepository orderrepo = new OrderRepository();
            try
            {
                orderrepo.getCustomerOrderbyid();
            }
            catch(Exception ex)
            {
                hlp.LogError(ex);
            }
            return orderrepo.getCustomerOrderbyid();
        }
   
    }
}
