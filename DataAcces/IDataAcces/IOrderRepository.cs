using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.IDataAcces
{
    public interface IOrderRepository
    {
         OrderRepository _orderRepository(OrderRepository orderrepo);
    }
}
