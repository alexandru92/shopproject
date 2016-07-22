using System;
using System.Collections.Generic;
using DataContracts.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataContracts;

namespace DataAcces
{
    public class OrderRepository
    {
        LogHelper hlp = new LogHelper();
        public List<CustomerOrder> getCustomerOrderbyid(int CustomerOrderID)
        {

            string conStr = ConfigurationManager.ConnectionStrings["ShopProjectSV"].ConnectionString;
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetAllCustomerOrderByID";
                    cmd.Parameters.AddWithValue("@CustomerOrderID", CustomerOrderID);
                    //cmd.Parameters["CustomerOrderID"].Direction = ParameterDirection.Output;
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

                foreach (DataRow row in table.Rows)
                {
                    CustomerOrder custorder = new CustomerOrder();
                    custorder.customerorderlistdetails = new Customer();
                    custorder.customerorderlistdetails.FirstName = row["FirstName"].ToString();
                    custorder.customerorderlistdetails.LastName = row["LastName"].ToString();
                    custorder.customerorderlistdetails.PhoneNumber = row["PhoneNumber"].ToString();
                    custorder.Total = Convert.ToInt32(row["Total"]);
                    custorderlist.Add(custorder);
                }
                return custorderlist;
            }
        }
        public void AddOrder(CustomerOrder customerOrder)
        {

        }
        public void UpdateOrder(CustomerOrder customerOrder)
        {
        }
    }
}
