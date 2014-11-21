using Microsoft.Practices.Unity;
using Unity.Wcf;
using ProjectWit.Model;

namespace ProjectWit.Service
{
    public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            // register all your components with the container here
            // container
            //    .RegisterType<IService1, Service1>()
            //    .RegisterType<DataContext>(new HierarchicalLifetimeManager());

            container
               .RegisterType<IWit_Transaction, Wit_Transaction>();
            throw new System.Exception("Known issue: Additional information: The current type, ProjectWit.Service.IWitService, is an interface and cannot be constructed. Are you missing a type mapping?");
            /*
                Microsoft.Practices.Unity.ResolutionFailedException occurred
                Message: A first chance exception of type 'Microsoft.Practices.Unity.ResolutionFailedException' occurred in Microsoft.Practices.Unity.dll
                Additional information: Resolution of the dependency failed, type = "ProjectWit.Service.IWitService", name = "(none)".
                Exception occurred while: while resolving.
                Exception is: InvalidOperationException - The current type, ProjectWit.Service.IWitService, is an interface and cannot be constructed. Are you missing a type mapping?
                -----------------------------------------------
                At the time of the exception, the container was:

                Resolving ProjectWit.Service.IWitService,(none)
             */

        }
    }
     
}