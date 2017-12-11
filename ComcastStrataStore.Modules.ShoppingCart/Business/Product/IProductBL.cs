using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.Business.Product
{
    public interface IProductBL
    {
        ProductEntity GetProduct(int Id);

        ObservableCollection<ProductEntity> GetAllProducts();
    }
}
