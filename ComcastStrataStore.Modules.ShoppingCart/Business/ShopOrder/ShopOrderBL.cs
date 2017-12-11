using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using StoreDAL;

namespace ComcastStrataStore.Modules.ShoppingCart.Business.ShopOrder
{
    public class ShopOrderBL : IShopOrderBL
    {
        public void CreateOrder(ShopOrderEntity order)
        {
            ShopOrderDAL shopOrderDAL = new ShopOrderDAL();
            StoreEDM.ShopOrder newOrder = new StoreEDM.ShopOrder()
            {
                 Customer_Id = order.CustomerIde,
                 Id = order.Id,
                 Purchase_Date = order.PurchaseDate,
                 Total_Cost = order.TotalCost
            };

            shopOrderDAL.CreateOrder(newOrder);
        }

        public ObservableCollection<ShopOrderEntity> GetAllOrders(int id)
        {
            ShopOrderDAL shopOrderDAL = new ShopOrderDAL();
            var allOrders = shopOrderDAL.GetAllOrders(id);
            ObservableCollection<ShopOrderEntity> result = new ObservableCollection<ShopOrderEntity>();
            foreach (var orderItem in allOrders)
            {
                ShopOrderEntity newEntity = new ShopOrderEntity()
                {
                    Id = orderItem.Id,
                    CustomerIde = orderItem.Customer_Id,
                    TotalCost = orderItem.Total_Cost,
                    PurchaseDate = orderItem.Purchase_Date
                };

                result.Add(newEntity);
            }
            return result;
        }

        public ShopOrderEntity GetOrderById(int id, int OrderId)
        {
            ShopOrderDAL shopOrderDAL = new ShopOrderDAL();
            var rawShopOrder = shopOrderDAL.GetOrderById(id, OrderId);

            ShopOrderEntity result = new ShopOrderEntity()
            {
                Id = rawShopOrder.Id,
                CustomerIde = rawShopOrder.Customer_Id,
                TotalCost = rawShopOrder.Total_Cost,
                PurchaseDate = rawShopOrder.Purchase_Date
            };

            return result;
        }

        public ObservableCollection<ShopOrderEntity> GetOrderInDateRange(int id, DateTime from, DateTime to)
        {
            ShopOrderDAL shopOrderDAL = new ShopOrderDAL();
            var rawShopOrdersInRange = shopOrderDAL.GetOrderInDateRange(id, from, to);

            ObservableCollection<ShopOrderEntity> result = new ObservableCollection<ShopOrderEntity>();
            foreach (var orderItem in rawShopOrdersInRange)
            {
                ShopOrderEntity newEntity = new ShopOrderEntity()
                {
                    Id = orderItem.Id,
                    CustomerIde = orderItem.Customer_Id,
                    TotalCost = orderItem.Total_Cost,
                    PurchaseDate = orderItem.Purchase_Date
                };

                result.Add(newEntity);
            }
            return result;
        }
    }
}
