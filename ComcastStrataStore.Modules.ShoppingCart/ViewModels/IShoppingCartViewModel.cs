using ComcastStrataStore.Infrastructure;
using ComcastStrataStore.Modules.ShoppingCart.Models;
using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.ViewModels
{
    public interface IShoppingCartViewModel : IViewModel
    {
        //Shopping Cart 
        IShoppingCart ShoppingCart { get; set; }

        //Customer Loyalty
        CustomerLoyaltyType CustomerLoyalty { get; set; }

        //Owner of Cart
        CustomerEntity OwnerOfCart { get; set; }

        //Command increase quantity of Item
        DelegateCommand<string> IncreaseItemCommand { get; set; }

        //Command decrease quantity of Item
        DelegateCommand<string> DecreaseItemCommand { get; set; }

        //Command to AddItem to cart
        DelegateCommand AddItemCommand { get; set; }

        //Command to purchase everything in Cart
        DelegateCommand PurchaseCartCommand { get; set; }

        //Add items to shopping cart
        void AddToShoppingCart();

        //Increase Quantity of item in shopping cart
        void IncreaseQuantityOfItem(string item);

        //Remove all type of an item from list 
        void RemoveItemFromCart(string item);

        //Decrease Quantity of item in shopping cart
        void DecreaseQuantityOfItem(string item);

        //Return a comma seperated list of content in cart and relevant info
        string CartContentToString();

        //Method to purchase items in Cart
        void PurchaseItemsInCart();

        //Callback when event is received to save User Data
        void SuccesfullLogin(CustomerEntity customerEntity);
        
    }

    public enum CustomerLoyaltyType { Standard, Silver, Gold}
}
