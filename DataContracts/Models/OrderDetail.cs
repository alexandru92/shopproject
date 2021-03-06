﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public int CustomerOrderID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Customer cust { get; set; }
        public Inventory inventory { get; set; }
    }
}
