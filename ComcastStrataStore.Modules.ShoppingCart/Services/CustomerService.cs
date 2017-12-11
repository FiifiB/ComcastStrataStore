using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComcastStrataStore.Modules.ShoppingCart.Business.Customer;
using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using StoreEDM;

namespace ComcastStrataStore.Modules.ShoppingCart.Services
{
    public class CustomerService : ICustomerService
    {
        public bool DoesCustomerExist(string name, string email)
        {
            ICustomerBL customerBL = new CustomerBL();
            return customerBL.DoesCustomerExist(name, email);
        }

        public CustomerEntity GetCustomer(string name, string email)
        {
            ICustomerBL customerBL = new CustomerBL();
            var customer = customerBL.GetCustomer(name, email);            

            return customer;

        }

        public void UpdateBalance(string name, string email, double spend)
        {
            ICustomerBL customerBL = new CustomerBL();
            customerBL.UpdateBalance(name, email, spend);
        }
    }
}
