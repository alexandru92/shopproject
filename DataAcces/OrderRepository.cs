using DataContracts.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Models;

namespace DataAcces
{
    public class OrderRepository : ICustomerOrder
    {
        public List<CustomerOrder> getCustomerOrder(CustomerOrder customerorder)
        {
            throw new NotImplementedException();
        }
        public void AddOrder(CustomerOrder customerOrder)
        {

        }
        public void UpdateOrder(CustomerOrder customerOrder)
        {

        }
    }
}
