using StoreEDM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public Customer GetCustomer(string name, string email)
        {
            using (StoreEntities context = new StoreEntities())
            {
                Customer customer = context.Customers.Where(c => c.Name == name && c.E_mail == email).FirstOrDefault();
                return customer;
            }
        }

        public float GetCustomerBalance(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer newUpdatedCustomer, string name, string email)
        {
            using (StoreEntities context = new StoreEntities())
            {
                Customer customer = context.Customers.Where(c => c.Name == name && c.E_mail == email).FirstOrDefault();

                customer.Name = newUpdatedCustomer.Name;
                customer.E_mail = newUpdatedCustomer.E_mail;
                customer.Balance = newUpdatedCustomer.Balance;
                customer.Loyalty_status = newUpdatedCustomer.Loyalty_status;
                customer.Spend = newUpdatedCustomer.Spend;

                context.SaveChanges();

            }
        }
    }
}
