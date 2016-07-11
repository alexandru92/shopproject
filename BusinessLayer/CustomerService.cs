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
            CustomerRepository cust = new CustomerRepository();
            try
            {
                cust.getCustomer();

            }
            catch (Exception ex)
            {
                hlp.LogError(ex);
            }
            return cust.getCustomer();
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


