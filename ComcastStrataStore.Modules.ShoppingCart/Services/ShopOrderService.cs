using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComcastStrataStore.Modules.ShoppingCart.Business.ShopOrder;
using ComcastStrataStore.Modules.ShoppingCart.UIEntities;

namespace ComcastStrataStore.Modules.ShoppingCart.Services
{
    public class ShopOrderService : IShopOrderService
    {
        public void CreateOrder(ShopOrderEntity order)
        {
            IShopOrderBL shopOrderBL = new ShopOrderBL();
            shopOrderBL.CreateOrder(order);
        }

        public ObservableCollection<ShopOrderEntity> GetAllOrders(int id)
        {
            IShopOrderBL shopOrderBL = new ShopOrderBL();
            return shopOrderBL.GetAllOrders(id);
        }

        public ShopOrderEntity GetOrderById(int id, int OrderId)
        {
            IShopOrderBL shopOrderBL = new ShopOrderBL();
            return shopOrderBL.GetOrderById(id, OrderId);
        }

        public ObservableCollection<ShopOrderEntity> GetOrderInDateRange(int id, DateTime from, DateTime to)
        {
            IShopOrderBL shopOrderBL = new ShopOrderBL();
            return shopOrderBL.GetOrderInDateRange(id,from,to);
        }
    }
}
