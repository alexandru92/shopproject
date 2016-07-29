using System;
using System.Collections.Generic;
using DataContracts.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataContracts;
using DataContracts.Models.IModels;

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



        //Details about each order
        public List<AllCustomerOrderDetail> getAllCustomerOrderDetail(int CustomerID)
        {

            string conStr = ConfigurationManager.ConnectionStrings["ShopProjectSV"].ConnectionString;
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetCustomerOrder";
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
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

                List<AllCustomerOrderDetail> custorderlist = new List<AllCustomerOrderDetail>();

                foreach (DataRow row in table.Rows)
                {
                    AllCustomerOrderDetail allcustorderdetail = new AllCustomerOrderDetail();
                    allcustorderdetail.customerorder = new CustomerOrder();
                    allcustorderdetail.customerorderedproduct = new Product();
                    allcustorderdetail.customerorderlistdetails = new Customer();
                    allcustorderdetail.orderdetail = new OrderDetail();
                    allcustorderdetail.customerorderlistdetails.FirstName = row["FirstName"].ToString();
                    allcustorderdetail.customerorderlistdetails.LastName = row["LastName"].ToString();
                    allcustorderdetail.customerorderlistdetails.PhoneNumber = row["PhoneNumber"].ToString();
                    allcustorderdetail.orderdetail.Quantity = Convert.ToInt32(row["Quantity"]);
                    //allcustorderdetail.orderdetail.Price = Convert.ToDecimal(row["Price"]);
                    allcustorderdetail.customerorderedproduct.Category = row["Category"].ToString();
                    allcustorderdetail.customerorderedproduct.Description = row["Description"].ToString();
                    allcustorderdetail.customerorderedproduct.Name = row["Name"].ToString();
                    allcustorderdetail.customerorderedproduct.Price = Convert.ToDecimal(row["Price"]);
                    allcustorderdetail.customerorder.Total = Convert.ToInt32(row["Total"]);


                    custorderlist.Add(allcustorderdetail);
                }
                return custorderlist;
            }
        }


        public void AddOrder(int productID, int customerID, int quantity, decimal price)
        {
            string conStr = ConfigurationManager.ConnectionStrings["ShopProjectSV"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    OrderDetail orderdetail = new OrderDetail();
                    orderdetail.cust = new Customer();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AddCustomerOrderDetail";
                    cmd.Parameters.AddWithValue("@ProductID", orderdetail.ProductID = productID);
                    cmd.Parameters.AddWithValue("@CustomerID", orderdetail.cust.CustomerID = customerID);
                    cmd.Parameters.AddWithValue("@Quantity", orderdetail.Quantity = quantity);
                    cmd.Parameters.AddWithValue("@Price", orderdetail.Price = price);

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
        public void UpdateOrder(CustomerOrder customerOrder)
        {
        }
    }
}
