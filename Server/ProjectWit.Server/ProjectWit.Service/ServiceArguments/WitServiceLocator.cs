using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;
using System.Runtime.Serialization;
namespace ProjectWit.Service.ServiceArguments
{
    [DataContract]
    public class WitServiceLocator : NinjectModule
    {
        public override void Load()
        {
            Bind<IWit_Transaction>().To<Wit_Transaction>();
            Bind<IWit_Order>().To<Wit_Order>();
        }
    }
}