using StoreEDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDAL
{
    public interface ICustomerDAL
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomer(string name);
    }
}
