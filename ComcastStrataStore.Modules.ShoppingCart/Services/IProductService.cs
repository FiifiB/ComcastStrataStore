using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.Services
{
    public interface IProductService
    {
        //Method to get all Products
        ObservableCollection<ProductEntity> GetAllProducts();

        //Method to get Id
        ProductEntity GetProduct(int Id);

        //Method to update a specific product with an order
        void UpdateProductWithOrder(int Id, int OrderId);
    }
}
