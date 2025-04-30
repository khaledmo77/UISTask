using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Mvc;
using System.Web;
using System.Web.Mvc;
using TaskUIS.Contract;
using TaskUIS.Repository;
using TaskUIS.Services;
using TaskUIS.Repository;  
using TaskUIS.Services;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(YourAppNamespace.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(YourAppNamespace.App_Start.NinjectWebCommon), "Stop")]

namespace YourAppNamespace.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly IKernel _kernel = new StandardKernel();

        public static void Start()
        {
           
            RegisterServices(_kernel);

          
            DependencyResolver.SetResolver(new NinjectDependencyResolver(_kernel));
        }

        public static void Stop()
        {
            _kernel.Dispose();
        }

        private static void RegisterServices(IKernel kernel)
        {
 
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<IProductService>().To<ProductService>();

            kernel.Bind<ITransactionRepository>().To<TransactionRepository>();
            kernel.Bind<ITransactionService>().To<TransactionService>();

    
        }
    }
}
