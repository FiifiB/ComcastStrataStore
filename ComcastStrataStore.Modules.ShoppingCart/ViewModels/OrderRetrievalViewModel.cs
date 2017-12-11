using ComcastStrataStore.Infrastructure;
using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using ComcastStrataStore.Modules.ShoppingCart.Views;
using Prism.Mvvm;
using StoreEDM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.ViewModels
{
    public class OrderRetrievalViewModel : BindableBase, IOrderRetrievalViewModel
    {
        public IView View { get; set; }
        public ObservableCollection<ShopOrderEntity> UserOrders { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public OrderRetrievalViewModel(IOrderRetrievalView view)
        {
            View = view;
            View.ViewModel = this;
        }

        public void GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public void GetOrderByDateRange(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
