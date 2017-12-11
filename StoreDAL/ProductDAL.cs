using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreEDM;

namespace StoreDAL
{
    public class ProductDAL : IProductDAL
    {
        public List<Product> GetAllProducts()
        {
            using (StoreEntities context = new StoreEntities())
            {
                //Gets all products that havent been ordered
                List<Product> products = context.Products.Where(p => p.ShopOrder == null).ToList();

                return products;
            }
        }

        public Product GetProduct(int Id)
        {
            using (StoreEntities context = new StoreEntities())
            {
                Product product = context.Products.Where(p => p.Id == Id).FirstOrDefault();
                return product;
            }
        }

        public void UpdateProductWithOrder(int Id, int OrderId)
        {
            using (StoreEntities context = new StoreEntities())
            {
                Product product = context.Products.Where(p => p.Id == Id).FirstOrDefault();
                product.Shop_Order = OrderId;
                context.SaveChanges();
            }
        }
    }
}
