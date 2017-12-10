using StoreEDM;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDAL
{
    public class CustomerDAL : ICustomerDAL
    {
        public List<Customer> GetAllCustomers()
        {
            using (StoreEntities context  = new StoreEntities())
            {
                List<Customer> customers  = context.Customers.ToList();

                return customers;
            }
        }

        public Customer GetCustomer(string name)
        {
            using (StoreEntities context = new StoreEntities())
            {
                Customer customer = context.Customers.Where(c => c.Name == name).FirstOrDefault();

                return customer;
            }
        }
    }
}
