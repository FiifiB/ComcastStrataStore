using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreEDM;

namespace ComcastStrataStore.Modules.ShoppingCart.Business.Customer
{
    public interface ICustomerBL
    {
        //Method to check if Customer Exist
        bool DoesCustomerExist(string name, string email);

        //Method get customer details
        StoreEDM.Customer GetCustomer(string name, string email);

        //Method to update balance and update loyalty status
        void UpdateBalance(string name, string email, double spend);
        
    }
}
