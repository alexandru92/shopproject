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
        ////LogHelper hlp = new LogHelper();
        ////Customer cust = null;
        ////private readonly ICustomerRepository _repository;
        ////public List<Customer> getcustList(GetCustomers getCustomersList)
        ////{
        ////    List<Customer> custlist = new List<Customer>();
        ////    try
        ////    {
        ////       custlist= getCustomersList.getCustomersList(cust);
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        hlp.LogError(ex);
        ////    }
        ////    return custlist;
        //private readonly ICustomerRepository _repository;
        //public CustomerService(ICustomerRepository repository)
        //{
        //    _repository = repository;
        //}
        //public List<Customer> getcustomerList(CustomerRepository getCustomersList)
        //{
        //    return _repository.getcustomerList(getCustomersList);
        //}
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
    }
   
}


