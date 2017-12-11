using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
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
    public interface ICartItem 
    {
        /// <summary>
        /// artItem Name which is also the name of the product it holds
        /// </summary>
        string NameOfProduct { get; set; }

        /// <summary>
        /// Collection to hold one type of product
        /// </summary>
        ObservableCollection<ProductEntity> Products { get; set; }

        /// <summary>
        /// Number of products in cart item
        /// </summary>
        int NumberOfProducts { get; }

        /// <summary>
        /// The price of one product
        /// </summary>
        float Price { get; set; }

        /// <summary>
        /// The total price of the product
        /// </summary>
        float TotalPrice { get; }

        void IncreaseCartItem();

        void DecreaseCartItem();
    }
}
