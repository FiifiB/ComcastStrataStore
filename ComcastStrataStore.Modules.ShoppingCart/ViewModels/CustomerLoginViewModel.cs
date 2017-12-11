using ComcastStrataStore.Infrastructure;
using ComcastStrataStore.Modules.ShoppingCart.Services;
using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using ComcastStrataStore.Modules.ShoppingCart.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Resolution;

namespace ComcastStrataStore.Modules.ShoppingCart.ViewModels
{
    public class CustomerLoginViewModel: BindableBase, ICustomerLoginViewModel
    {
        public IView View { get; set; }
        public string CustomerName { get ; set ; }
        public string CustomerEmail { get ; set ; }
        public DelegateCommand LoginCommand { get; set; }

        IRegionManager _regionManager { get; set; }
        IUnityContainer _container { get; set; }
        IEventAggregator _eventAggregator { get; set; }
        public CustomerLoginViewModel(ICustomerLoginView view, IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator)
        {
            View = view;
            View.ViewModel = this;
            _regionManager = regionManager;
            _container = unityContainer;
            _eventAggregator = eventAggregator;
            LoginCommand = new DelegateCommand(CreateShoppingCart);
        }

        public void CreateShoppingCart()
        {
            CustomerService customerService = new CustomerService();
            CustomerEntity customerEntity;
            try
            {
                var exist = customerService.DoesCustomerExist(CustomerName, CustomerEmail);
                customerEntity = customerService.GetCustomer(CustomerName, CustomerEmail);
            }
            catch (Exception)
            {

                MessageBox.Show("Error finding account");
                return;
            }

            IRegion region = _regionManager.Regions[RegionNames.MainRegion];
            var vm = _container.Resolve<IShoppingCartViewModel>(new ResolverOverride[] { new ParameterOverride("ShoppingCartId", customerEntity.Id) });
            _eventAggregator.GetEvent<RecieveUserDataEvent>().Publish(customerEntity);
            region.Remove(View);
            region.Add(vm.View);
            region.Activate(vm.View);

        }
    }
}
