using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAcces
{
    public class InventoryRepository
    {
        LogHelper hlp = new LogHelper();
        public void AddInventory(/*int productid, int quantity*/ Inventory inventory)
        {

            string conStr = ConfigurationManager.ConnectionStrings["ShopProjectSV"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    //Inventory inventory = new Inventory();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spAddInventory";
                    cmd.Parameters.AddWithValue("@ProductID", inventory.ProductID/* = productid*/);
                    cmd.Parameters.AddWithValue("@Quantity", inventory.Quantity /*= productid*/);
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


        public List<Inventory> getInventory()
        {
            string conStr = ConfigurationManager.ConnectionStrings["ShopProjectSV"].ConnectionString;
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetInventory";
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

                List<Inventory> inventorylist = new List<Inventory>();
                foreach (DataRow row in table.Rows)
                {
                    Inventory inventory = new Inventory();
                    inventory.prod = new Product();
                    inventory.ProductID = Convert.ToInt32(row["ProductID"]);
                    inventory.Quantity = Convert.ToInt32(row["Quantity"]);
                    inventory.prod.Name = row["Name"].ToString();
                    inventory.prod.Category = row["Category"].ToString();
                    inventory.prod.Description = row["Description"].ToString();
                    inventory.prod.Price = Convert.ToInt32(row["Price"]);
                    inventorylist.Add(inventory);
                }
                return inventorylist;
            }
        }

        public void UpdateInventory(/*int productid, int quantity*/ Inventory inventory)
        {

            string conStr = ConfigurationManager.ConnectionStrings["ShopProjectSV"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    //Inventory inventory = new Inventory();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spAddInventory";
                    cmd.Parameters.AddWithValue("@ProductID", inventory.ProductID/* = productid*/);
                    cmd.Parameters.AddWithValue("@Quantity", inventory.Quantity /*= productid*/);
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
    }
}
