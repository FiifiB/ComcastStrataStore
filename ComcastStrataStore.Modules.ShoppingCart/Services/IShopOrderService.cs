using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.Services
{
    public interface IShopOrderService
    {
        ObservableCollection<ShopOrderEntity> GetOrderInDateRange(int id, DateTime from, DateTime to);
        ShopOrderEntity GetOrderById(int id, int OrderId);
        ObservableCollection<ShopOrderEntity> GetAllOrders(int id);
        void CreateOrder(ShopOrderEntity order);
    }
}
