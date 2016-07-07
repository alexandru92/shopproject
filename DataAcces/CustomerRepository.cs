using DataContracts;
using DataContracts.Models.iModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAcces
{
    public class CustomerRepository : ICustomer
    {
        public List<Customer> getCustomer(Customer cust)
        {
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
                    catch
                    {
                        throw;
                    }
                }
                List<Customer> custlist = new List<Customer>();
                foreach (DataRow row in table.Rows)
                {
                    cust.CustomerID = Convert.ToInt32(row["CustomerID"]);
                    cust.CustomerAddress.AddressID = Convert.ToInt32(row["AddressID"]);
                    cust.CustomerAddress.City = row["City"].ToString();
                    cust.CustomerAddress.Street = row["Street"].ToString();
                    cust.CustomerAddress.Country = row["Country"].ToString();
                    cust.FirstName = row["FirstName"].ToString();
                    cust.LastName = row["LastName"].ToString();
                    cust.PhoneNumber = row["PhoneNumber"].ToString();
                    cust.DateBirth = Convert.ToDateTime(row["DateBirth"]);
                    custlist.Add(cust);
                }
                return custlist;
            }
        }
        public void AddCustomer(Customer cust)
        {

        }
        public void UpdateCustomer(Customer cust)
        {

        }
    }
}



