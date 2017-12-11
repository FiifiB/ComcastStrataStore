using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using Prism.Mvvm;

namespace ComcastStrataStore.Modules.ShoppingCart.Models
{
    public class CartItem : BindableBase, ICartItem
    {
        public string NameOfProduct { get; set; }
        public ObservableCollection<ProductEntity> Products { get; set; }

        private int numberOfProducts;
        public int NumberOfProducts
        {
            get { return numberOfProducts; }
            set { SetProperty(ref numberOfProducts ,value); }
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { SetProperty(ref price , value); }
        }

        private float totalPrice;

        public float TotalPrice
        {
            get { return totalPrice; }
            set { SetProperty(ref totalPrice ,value); }
        }


        public CartItem(string nameOfProduct , ProductEntity product, float price)
        {
            NameOfProduct = nameOfProduct;
            Products = new ObservableCollection<ProductEntity>() { product };
            Price = price;
            NumberOfProducts = 1;
            TotalPrice = Price * NumberOfProducts;
        }

        public void DecreaseCartItem()
        {
            if (NumberOfProducts <= 1)
                throw new Exception("Cannot have a cart Item with 0 items or less");
            NumberOfProducts = NumberOfProducts - 1;
            TotalPrice = Price * NumberOfProducts;
        }

        public void IncreaseCartItem()
        {
            if (NumberOfProducts <= 0)
                throw new Exception("Cannot have a cart Item with 0 items or less");

            NumberOfProducts = NumberOfProducts + 1;
            TotalPrice = Price * NumberOfProducts;
        }
    }
}
