using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Models.iModels
{
    public interface IAddress
    {
        List<Address> getAddress(Address address);
    }
}
