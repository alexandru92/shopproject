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
        LogHelper hlp = new LogHelper();
        public List<Customer> getCustomer()
        {
            string conStr = ConfigurationManager.ConnectionStrings["ShopProjectSV"].ConnectionString;
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetAllCustomers";
                    //cmd.Parameters.AddWithValue("@CustomerOrderID");
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

                List<Customer> custlist = new List<Customer>();
                foreach (DataRow row in table.Rows)
                {
                    Customer cust = new Customer();
                    cust.address = new Address();
                    cust.FirstName = row["FirstName"].ToString();
                    cust.LastName = row["LastName"].ToString();
                    cust.PhoneNumber = row["PhoneNumber"].ToString();
                    cust.DateBirth = Convert.ToDateTime(row["DateBirth"]);
                    cust.address.City = row["City"].ToString();
                    cust.address.Street = row["Street"].ToString();
                    cust.address.Country = row["Country"].ToString();
                    custlist.Add(cust);
                }
                return custlist;
            }
        }

        public List<CustomerOrder> getOrderByCustomerID()
        {
            string conStr = ConfigurationManager.ConnectionStrings["ShopProjectSV"].ConnectionString;
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetAllOrdersByCustomerID";
                    //cmd.Parameters.AddWithValue("@CustomerOrderID");
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

                List<CustomerOrder> custorderlist = new List<CustomerOrder>();

                //DateTime date = new DateTime();
                //string formatdate = date.ToString("dd-MM-yyyy");
                foreach (DataRow row in table.Rows)
                {
                    CustomerOrder custorder = new CustomerOrder();
                    custorder.custorderdetails.FirstName = row["FirstName"].ToString();
                    custorder.custorderdetails.LastName = row["LastName"].ToString();
                    custorderlist.Add(custorder);
                }
                return custorderlist;
            }
        }

        public void AddCustomer(Customer cust)
        {

            string conStr = ConfigurationManager.ConnectionStrings["ShopProjectSV"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spAddCustomer";
                    cmd.Parameters.AddWithValue("@FirstName", cust.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", cust.LastName);
                    cmd.Parameters.AddWithValue("@DateBirth", cust.DateBirth);
                    cmd.Parameters.AddWithValue("@PhoneNumber", cust.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Street", cust.address.Street);
                    cmd.Parameters.AddWithValue("@City", cust.address.City);
                    cmd.Parameters.AddWithValue("@Country", cust.address.Country);
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        hlp.LogError(ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public void UpdateCustomer(Customer cust)
        {

        }
    }
}



