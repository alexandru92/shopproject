using DataContracts;
using DataContracts.Models;
using DataContracts.Models.iModels;
using DataContracts.Models.IModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAcces
{
    public class CustomerRepository
    {
        Address address = new Address();

        public List<Customer> getCustomer()
        {
            LogHelper hlp = new LogHelper();
            Customer cust = new Customer();
            Address address = new Address();

            string conStr = ConfigurationManager.ConnectionStrings["ShopProjectSV"].ConnectionString;
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetAllCustomers";
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            da.Fill(table);
                        }
                    }
                    catch (Exception ex)
                    {
                        hlp.LogError(ex);
                    }
                }
                NewCustomer customerandaddress = new NewCustomer();
                CustomerAndAddress custandaddresslist = new CustomerAndAddress();

                List<Customer> custlist = new List<Customer>();
                List<Address> addresslist = new List<Address>();

                DateTime date = new DateTime();
                string formatdate = date.ToString("dd-MM-yyyy");
                foreach (DataRow row in table.Rows)
                {
                    
                    //custandaddresslist.customer.FirstName = row["FirstName"].ToString();
                    //custandaddresslist.customer.LastName = row["LastName"].ToString();
                    //custandaddresslist.customer.PhoneNumber = row["PhoneNumber"].ToString();
                    //custandaddresslist.customer.DateBirth = Convert.ToDateTime(row["DateBirth"]);
                    //custandaddresslist.address.City = row["City"].ToString();
                    //custandaddresslist.address.Street = row["Street"].ToString();
                    //custandaddresslist.address.Country = row["Country"].ToString();
                    //cust.CustomerID = Convert.ToInt32(row["CustomerID"]);
                    //cust.CustomerAddress.AddressID = Convert.ToInt32(row["AddressID"]);
                    cust.FirstName = row["FirstName"].ToString();
                    cust.LastName = row["LastName"].ToString();
                    cust.PhoneNumber = row["PhoneNumber"].ToString();
                    cust.DateBirth = Convert.ToDateTime(row["DateBirth"]);
                    //cust.address.City = row["City"].ToString();
                    //cust.address.Street = row["Street"].ToString();
                    //cust.address.Country = row["Country"].ToString();
                    custlist.Add(cust);
                    

                }
                return custlist;
            }
        }

        //public CustomerRepository getCustomer()
        //{
        //    throw new NotImplementedException();
        //}

        public void AddCustomer(Customer cust)
        {

        }
        public void UpdateCustomer(Customer cust)
        {

        }
    }
}



