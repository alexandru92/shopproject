using DataContracts;
using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAcces
{
    public class InventoryRepo
    {
        LogHelper hlp = new LogHelper();
        public List<Product> getProduct()
        {
            string conStr = ConfigurationManager.ConnectionStrings["ShopProjectSV"].ConnectionString;
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetAllProducts";
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

                List<Product> productlist = new List<Product>();

                //DateTime date = new DateTime();
                //string formatdate = date.ToString("dd-MM-yyyy");
                foreach (DataRow row in table.Rows)
                {
                    Product prod = new Product();
                    prod.ProductID = Convert.ToInt32(row["ProductID"]);
                    prod.Name= row["Name"].ToString();
                    prod.Description = row["Description"].ToString();
                    prod.Category = row["Category"].ToString();
                    prod.Price = Convert.ToInt32(row["Price"]);
                    productlist.Add(prod);
                }
                return productlist;
            }
        }

        public void AddProduct(Product prod)
        {

            string conStr = ConfigurationManager.ConnectionStrings["ShopProjectSV"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spAddProduct";
                    cmd.Parameters.AddWithValue("@Name", prod.Name);
                    cmd.Parameters.AddWithValue("@Description", prod.Description);
                    cmd.Parameters.AddWithValue("@Category", prod.Category);
                    cmd.Parameters.AddWithValue("@Price", prod.Price);

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



