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
    public interface IShoppingCart : INotifyPropertyChanged
    {
        //Shopping cart id representing Customer
        string ShoppingCartID { get; set; }

        //Items held by in the shopping cart
        ObservableCollection<ICartItem> CartItems { get; set; }

        //Total Cost of the shopping cart
        float TotalCost { get; set; }

    }
}
