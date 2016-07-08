using DataContracts.Models;
using System;
using System.Collections.Generic;

namespace DataContracts
{
    public class Customer
    {
       public int CustomerID { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public DateTime DateBirth { get; set; }
       public string PhoneNumber { get; set; }
       public Address address { get; set; }
    }

}
