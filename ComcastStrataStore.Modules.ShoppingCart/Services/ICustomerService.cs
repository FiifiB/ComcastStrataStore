using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.Services
{
    public interface ICustomerService
    {
        bool DoesCustomerExist(string name, string email);

        CustomerEntity GetCustomer(string name, string email);

        void UpdateBalance(string name, string email, double spend);
    }
}
