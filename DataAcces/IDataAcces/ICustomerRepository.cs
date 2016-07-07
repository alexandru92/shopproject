using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.IDataAcces
{
    public interface ICustomerRepository
    {
        //List<Customer> getcustomerList(CustomerRepository getCustomerRepositoryList);
        CustomerRepository _customerRepository(CustomerRepository customerrepo);
    }
}
