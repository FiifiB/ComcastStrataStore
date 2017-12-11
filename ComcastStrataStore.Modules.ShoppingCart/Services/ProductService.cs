using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComcastStrataStore.Modules.ShoppingCart.Business.Product;
using ComcastStrataStore.Modules.ShoppingCart.UIEntities;

namespace ComcastStrataStore.Modules.ShoppingCart.Services
{
    public class ProductService : IProductService
    {
        public ObservableCollection<ProductEntity> GetAllProducts()
        {
            IProductBL productBL = new ProductBL();
            return productBL.GetAllProducts();
        }

        public ProductEntity GetProduct(int Id)
        {
            IProductBL productBL = new ProductBL();
            return productBL.GetProduct(Id);
        }
    }
}
