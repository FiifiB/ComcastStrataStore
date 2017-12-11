using StoreEDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDAL
{
    public interface IShopOrderDAL
    {
        List<ShopOrder> GetOrderInDateRange(int id, DateTime from, DateTime to);
        ShopOrder GetOrderById(int id, int OrderId);
        List<ShopOrder> GetAllOrders(int id);
        void CreateOrder(ShopOrder order);
    }
}
