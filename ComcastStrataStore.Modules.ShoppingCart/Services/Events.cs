using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.Services
{
    class RecieveUserDataEvent : PubSubEvent<CustomerEntity>
    {
    }
}
