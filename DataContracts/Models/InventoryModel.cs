﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Models
{
    class InventoryModel
    {
        public int InventoryID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
    }
}
