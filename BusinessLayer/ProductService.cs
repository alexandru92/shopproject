using DataAcces;
using DataContracts.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ProductService
    {
        LogHelper hlp = new LogHelper();

        
        public List<Product> GetProduct()
        {
            InventoryRepo prod = new InventoryRepo();
            try
            {
                prod.getProduct();

            }
            catch (Exception ex)
            {
                hlp.LogError(ex);
            }
            return prod.getProduct();
        }
        public void AddProduct(Product prod)
        {
            InventoryRepo prodrepo = new InventoryRepo();
            try
            {
                prodrepo.AddProduct(prod);
            }
            catch (Exception ex)
            {
                hlp.LogError(ex);
            }
        }
    }
}

