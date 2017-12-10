using ComcastStrataStore.Modules.ShoppingCart.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using ComcastStrataStore.Modules.ShoppingCart.ViewModels;
using ComcastStrataStore.Infrastructure;

namespace ComcastStrataStore.Modules.ShoppingCart
{
    public class ShoppingCartModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ShoppingCartModule(UnityContainer container, RegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterViewAndServices();

            IRegion region = _regionManager.Regions[RegionNames.MainRegion];
            var vm = _container.Resolve<CustomerLoginViewModel>();
            region.Add(vm.View);
            region.Activate(vm.View);
        }

        public void RegisterViewAndServices()
        {
            _container.RegisterType<ICustomerLoginView,CustomerLoginView>();
            _container.RegisterType<ICustomerLoginViewModel, CustomerLoginViewModel>();
        }
    }
}