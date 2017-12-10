using ComcastStrataStore.Modules.ShoppingCart;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ComcastStrataStore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// Creates the shell.
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        /// <summary>
        /// Configures the module catalog.
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            /*
            * The ModuleCatalog class holds information about th  modules that can be used by the applicaiton.
            * ModuleInfo class tha records the name, type, and location, among the attributes on of the module.
            */

            base.ConfigureModuleCatalog(moduleCatalog);

            Type ShoppingCartType = typeof(ShoppingCartModule);

            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = ShoppingCartType.Name,
                ModuleType = ShoppingCartType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

    }
}
