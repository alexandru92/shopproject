using DataAcces;
using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class InventoryService
    {
        InventoryRepository inventoryrepo = new InventoryRepository();
        LogHelper hlp = new LogHelper();
        public List<Inventory> Getcustorder()
        {
            List<Inventory> inventorylist = new List<Inventory>();
            try
            {
                inventorylist = inventoryrepo.getInventory();
            }
            catch (Exception ex)
            {
                hlp.LogError(ex);
            }
            return inventorylist;
        }

        public void AddInventory(/*int productid, int quantity*/ Inventory inventory)
        {
            try
            {
                inventoryrepo.AddInventory(inventory);
            }
            catch (Exception ex)
            {
                hlp.LogError(ex);
            }
        }
    }

}
