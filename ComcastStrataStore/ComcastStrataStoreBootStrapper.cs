using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using System.Windows;
using Prism.Modularity;
using ComcastStrataStore.Modules.ShoppingCart;

namespace ComcastStrataStore
{
    /// <summary>
    /// Boot Strapper class responsible for initialization of an Application
    /// </summary>
    public class ComcastStrataStoreBootStrapper : UnityBootstrapper
    {

        /// <summary>
        /// Creates the shell.
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject CreateShell()
        {
            return (DependencyObject)Container.Resolve(typeof(Shell),"Shell");
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures the module catalog.
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
           /*
            * The ModuleCatalog class holds information about th  modules that can be used by the applicaiton.
            * ModuleInfo class tha records the name, type, and location, among the attributes on of the module.
            */

            base.ConfigureModuleCatalog();

            Type ShoppingCartType = typeof(ShoppingCartModule);

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = ShoppingCartType.Name,
                ModuleType = ShoppingCartType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });
        }

        /// <summary>
        /// A container to Configures and injecting the required dependencies and services.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }
    }
}
