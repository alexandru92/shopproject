﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Models
{
   public class Address
    {
        public int AddressID { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
    }

}
