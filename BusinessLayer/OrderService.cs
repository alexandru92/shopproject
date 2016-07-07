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

        public OrderRepository _orderRepository(OrderRepository orderrepo)
        {
            throw new NotImplementedException();
        }
    }
}
