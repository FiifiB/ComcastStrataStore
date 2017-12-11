using ComcastStrataStore.Infrastructure;
using ComcastStrataStore.Modules.ShoppingCart.Services;
using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using ComcastStrataStore.Modules.ShoppingCart.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using StoreEDM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ComcastStrataStore.Modules.ShoppingCart.ViewModels
{
    public class OrderRetrievalViewModel : BindableBase, IOrderRetrievalViewModel
    {
        public IView View { get; set; }
        //public ObservableCollection<ShopOrderEntity> UserOrders { get; set; }
        private ObservableCollection<ShopOrderEntity> userOrders;

        public ObservableCollection<ShopOrderEntity> UserOrders
        {
            get { return userOrders; }
            set { SetProperty(ref userOrders , value); }
        }

        IRegionManager _regionManager { get; set; }
        IUnityContainer _container { get; set; }
        IEventAggregator _eventAggregator { get; set; }


        public CustomerEntity OwnerOfCart { get; set; }
        public DelegateCommand SearchByIdCommand { get; set; }
        public DelegateCommand SearchByDateRangeCommand { get; set; }
        public DateTime FromSelectedDate { get; set; }
        public DateTime ToSelectedDate { get; set; }
        public DelegateCommand GetAllOrdersCommand { get; set; }
        public string IdTextBox { get; set; }

        public OrderRetrievalViewModel(IOrderRetrievalView view, IEventAggregator eventAggregator)
        {
            View = view;
            View.ViewModel = this;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<RecieveUserDataEvent>().Subscribe(RecieveAccountInfo);

            SearchByIdCommand = new DelegateCommand(GetOrderById);
            SearchByDateRangeCommand = new DelegateCommand(GetOrderByDateRange);
            GetAllOrdersCommand = new DelegateCommand(GetAllOrdersByUser);
        }

        public void GetOrderById()
        {
            ShopOrderService shopOrderService = new ShopOrderService();
            int idSpecified;
            int.TryParse(IdTextBox, out idSpecified);
            var order = shopOrderService.GetOrderById(OwnerOfCart.Id, idSpecified);
            UserOrders = new ObservableCollection<ShopOrderEntity>() { order };
        }

        public void GetOrderByDateRange()
        {
            ShopOrderService shopOrderService = new ShopOrderService();
            UserOrders = shopOrderService.GetOrderInDateRange(OwnerOfCart.Id, FromSelectedDate, ToSelectedDate);
        }

        public void GetAllOrdersByUser()
        {
            ShopOrderService shopOrderService = new ShopOrderService();
            UserOrders = shopOrderService.GetAllOrders(OwnerOfCart.Id);
        }

        public void RecieveAccountInfo(CustomerEntity customerEntity)
        {
            OwnerOfCart = customerEntity;
        }

    }
}
