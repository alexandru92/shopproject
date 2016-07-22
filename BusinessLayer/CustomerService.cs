using DataAcces;
using DataAcces.IDataAcces;
using DataContracts;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{

    public class CustomerService : ICustomerRepository
    {
        LogHelper hlp = new LogHelper();

        public CustomerRepository _customerRepository(CustomerRepository customerrepo)
        {
            throw new NotImplementedException();
        }
        public List<Customer> GetCustomer()
        {
            CustomerRepository custrepo = new CustomerRepository();
            try
            {
                custrepo.getCustomer();

            }
            catch (Exception ex)
            {
                hlp.LogError(ex);
            }
            return custrepo.getCustomer();
        }
        public void AddCustomer(Customer cust)
        {
            CustomerRepository custrepo = new CustomerRepository();
            try
            {
                custrepo.AddCustomer(cust);
            }
            catch (Exception ex)
            {
                hlp.LogError(ex);
            }
        }
    }

}


