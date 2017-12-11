using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.Models
{
    public class ShoppingCartModel :  BindableBase, IShoppingCart
    {
        private readonly int _shoppingCartID;
        public int ShoppingCartID
        {
            get { return _shoppingCartID; }            
        }

        private ObservableCollection<ICartItem> cartItems;
        public ObservableCollection<ICartItem> CartItems
        {
            get { return cartItems; }
            set { SetProperty(ref cartItems, value); }
        }

        public ShoppingCartModel(int shoppingCartID)
        {
            _shoppingCartID = shoppingCartID;
            cartItems = new ObservableCollection<ICartItem>();
        }

        public void AddItemToCart(ProductEntity item)
        {
            if (cartItems.Count == 0)
            {
                CartItem newCartItem = new CartItem(item.Name, item, (float)item.UnitPrice);
                CartItems.Add(newCartItem);
                RaisePropertyChanged("CartItems");
                return;
            }
            foreach (var cItem in cartItems)
            {
                if (cItem.NameOfProduct == item.Name)
                {
                    cItem.IncreaseCartItem();
                    cItem.Products.Add(item);
                    return;
                }                
            }
            CartItem aCartItem = new CartItem(item.Name, item, (float)item.UnitPrice);
            CartItems.Add(aCartItem);
            RaisePropertyChanged("CartItems");

        }

        public ProductEntity RemoveItemFromCart(string itemName)
        {
            var cartItem = cartItems.First(i => i.NameOfProduct == itemName);
            try
            {
                cartItem.DecreaseCartItem();
                var itemToRemove = cartItem.Products.Last();
                cartItem.Products.Remove(itemToRemove);                
                RaisePropertyChanged("CartItems");
                return itemToRemove;
            }
            catch (Exception)
            {
                var itemToRemove1 = cartItem.Products.Last();
                cartItems.Remove(cartItem);
                RaisePropertyChanged("CartItems");
                return itemToRemove1;
            }
        }

        public float TotalCost()
        {
            float totalCost = 0;
            foreach (var cItem in cartItems)
            {
                totalCost += cItem.TotalPrice;
            }
            return totalCost;
        }
    }
}
