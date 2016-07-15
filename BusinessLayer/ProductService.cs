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
            ProductRepository prod = new ProductRepository();
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
            ProductRepository prodrepo = new ProductRepository();
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

