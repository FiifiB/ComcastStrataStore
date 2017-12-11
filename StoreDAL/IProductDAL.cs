using StoreEDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDAL
{
    public interface IProductDAL
    {
        List<Product> GetAllProducts();
        Product GetProduct(int Id);
        void UpdateProductWithOrder(int Id, int OrderId);
    }
}
