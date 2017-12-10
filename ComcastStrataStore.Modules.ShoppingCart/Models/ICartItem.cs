using StoreEDM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.Models
{
    public interface ICartItem : INotifyPropertyChanged
    {
        //CartItem Name which is also the name of the product it holds
        string NameOfProduct { get; set; }

        //Collection to hold one type of product
        ObservableCollection<Product> Products { get; set; }

        //Number of products in cart item
        int NumberOfProducts { get; set; }

        //The price of one product
        float Price { get; set; }

        //The total price of the product
        float TotalPrice { get; set; }
    }
}
