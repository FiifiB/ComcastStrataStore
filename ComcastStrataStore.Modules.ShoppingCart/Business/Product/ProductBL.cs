using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using StoreDAL;

namespace ComcastStrataStore.Modules.ShoppingCart.Business.Product
{
    public class ProductBL : IProductBL
    {
        public ObservableCollection<ProductEntity> GetAllProducts()
        {
            ProductDAL productDAL = new ProductDAL();
            var rawProducts = productDAL.GetAllProducts();
            ObservableCollection<ProductEntity> result = new ObservableCollection<ProductEntity>();

            foreach (var rawProduct in rawProducts)
            {
                ProductEntity productEntity = new ProductEntity()
                {
                    Id = rawProduct.Id,
                    Name = rawProduct.Name,
                    UnitPrice = rawProduct.Unit_Price
                };
                result.Add(productEntity);
            }

            return result;
        }

        public ProductEntity GetProduct(int Id)
        {
            ProductDAL productDAL = new ProductDAL();
            var rawProduct = productDAL.GetProduct(Id);

            ProductEntity productEntity = new ProductEntity()
            {
                Id = rawProduct.Id,
                Name = rawProduct.Name,
                UnitPrice = rawProduct.Unit_Price
            };
            return productEntity;
        }

        public void UpdateProductWithOrder(int Id, int OrderId)
        {
            ProductDAL productDAL = new ProductDAL();
            productDAL.UpdateProductWithOrder(Id, OrderId);
        }
    }
}
