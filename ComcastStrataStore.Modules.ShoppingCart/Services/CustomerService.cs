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

            CustomerEntity customerEntity = new CustomerEntity()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.E_mail,
                Balance = customer.Balance,
                Spend = customer.Spend,                

            };

            switch (customer.Loyalty_status)
            {
                case "Standard":
                    customerEntity.LoyaltyStatus = ViewModels.CustomerLoyaltyType.Standard;
                    break;
                case "Silver":
                    customerEntity.LoyaltyStatus = ViewModels.CustomerLoyaltyType.Silver;
                    break;
                case "Gold":
                    customerEntity.LoyaltyStatus = ViewModels.CustomerLoyaltyType.Gold;
                    break;
                default:
                    break;
            }

            return customerEntity;

        }
    }
}
