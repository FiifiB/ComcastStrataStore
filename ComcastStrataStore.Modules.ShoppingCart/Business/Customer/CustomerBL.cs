using StoreDAL;
using StoreEDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.Business.Customer
{
    public class CustomerBL : ICustomerBL
    {
        /// <summary>
        /// Check to see if customer exist using the name and email
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool DoesCustomerExist(string name, string email)
        {
            ICustomerDAL customerDAL = new CustomerDAL();
            var result = customerDAL.GetCustomer(name, email);

            if (result == null)
                throw new Exception("Account doesnt exist");
            return true;
        }

        /// <summary>
        /// Retrieve an object with customer details
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public StoreEDM.Customer GetCustomer(string name, string email)
        {
            ICustomerDAL customerDAL = new CustomerDAL();
            var result = customerDAL.GetCustomer(name, email);
            if (result == null)
                throw new Exception("Account doesnt exist");
            return result;
        }

        /// <summary>
        /// Update the balance of a customer and ammends loyalty status if needed
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="spend"></param>
        public void UpdateBalance(string name, string email, double spend)
        {
            ICustomerDAL customerDAL = new CustomerDAL();
            var customer = customerDAL.GetCustomer(name, email);

            //Check status after new spend
            var newTotalSpend = customer.Spend + spend;
            string newLoyaltyStatus;
            if (newTotalSpend > 1500)
            {
                newLoyaltyStatus = "Gold";
            }
            else if (newTotalSpend > 500)
            {
                newLoyaltyStatus = "Silver";
            }
            else
            {
                newLoyaltyStatus = "Standard";
            }

            // Update the balance loyalty status and spend
            var customerUpdated = new StoreEDM.Customer();
            customerUpdated.Name = customer.Name;
            customerUpdated.E_mail = customer.E_mail;
            customerUpdated.Balance = customer.Balance - spend;
            customerUpdated.Loyalty_status = newLoyaltyStatus;
            customerUpdated.Spend = newTotalSpend;

            customerDAL.UpdateCustomer(customerUpdated, customer.Name, customer.E_mail);

        }
    }
}
