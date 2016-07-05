using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    public class CustomerModel
    {
        int CustomerID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateBirth { get; set; }
        string PhoneNumber { get; set; }
        int AddressID { get; set; }
    }
}
