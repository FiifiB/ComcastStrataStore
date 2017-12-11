using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using Prism.Mvvm;
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
    public interface IShoppingCart 
    {
        //Shopping cart id representing Customer
        int ShoppingCartID { get; }

        //Items held by in the shopping cart
        ObservableCollection<ICartItem> CartItems { get; set; }

        //Total Cost of the shopping cart
        float TotalCost();

        //Add item to Cart
        void AddItemToCart(ProductEntity item);

        //Remove item from cart and returns it back to stock
        ProductEntity RemoveItemFromCart(string itemName);


    }
}
