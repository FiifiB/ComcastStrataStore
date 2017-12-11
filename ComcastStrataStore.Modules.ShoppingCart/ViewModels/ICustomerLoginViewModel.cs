using ComcastStrataStore.Infrastructure;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.ViewModels
{
    public interface ICustomerLoginViewModel : IViewModel
    {
        //Command to Login with Name and Email
        DelegateCommand LoginCommand { get; set; }

        //Customer Name entered
        string CustomerName { get; set; }

        //Customer Email entered
        string CustomerEmail { get; set; }

        //Method used to create ShoppingCart
        void CreateShoppingCart();
    }
}
