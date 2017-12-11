using ComcastStrataStore.Modules.ShoppingCart.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using ComcastStrataStore.Modules.ShoppingCart.ViewModels;
using ComcastStrataStore.Infrastructure;
using Unity;

namespace ComcastStrataStore.Modules.ShoppingCart
{
    public class ShoppingCartModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ShoppingCartModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
            
        }

        public void Initialize()
        {
            RegisterViewAndServices();

            IRegion region = _regionManager.Regions[RegionNames.MainRegion];
            var vm = _container.Resolve<ICustomerLoginViewModel>();
            region.Add(vm.View);
            region.Activate(vm.View);
        }

        public void RegisterViewAndServices()
        {
            _container.RegisterType<ICustomerLoginView,CustomerLoginView>();
            _container.RegisterType<ICustomerLoginViewModel, CustomerLoginViewModel>();

            _container.RegisterType<IShoppingCartView, ShoppingCartView>();
            _container.RegisterType<IShoppingCartViewModel, ShoppingCartViewModel>();

            _container.RegisterType<IOrderRetrievalView, OrderRetrievalView>();
            _container.RegisterType<IOrderRetrievalViewModel, OrderRetrievalViewModel>();
        }
    }
}