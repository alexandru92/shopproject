using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Models.IModels
{
   public class AllCustomerOrderDetail
    {
        public Customer customerorderlistdetails { get; set; }
        public Product customerorderedproduct { get; set; }
        public CustomerOrder customerorder { get; set; }
        public OrderDetail orderdetail { get; set; }
    }
}
