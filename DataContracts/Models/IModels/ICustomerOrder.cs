using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Models.IModels
{
    public interface ICustomerOrder
    {
        List<CustomerOrder> getCustomerOrder(CustomerOrder customerorder);
    }
}
