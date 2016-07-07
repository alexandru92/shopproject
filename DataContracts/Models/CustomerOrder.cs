using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Models
{
    public class CustomerOrder
    {
        public int CustomerOrderID { get; set; }
        public int CustomerID { get; set; }
        public int Total { get; set; }
    }
}
