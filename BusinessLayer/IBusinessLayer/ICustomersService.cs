using DataAcces;
using DataContracts;
using System.Collections.Generic;

namespace BusinessLayer.IBusinessLayer
{
    public interface ICustomersService
    {
        CustomerService _customerservice(CustomerService customerservice);
    }
}
