[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CompanyApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CompanyApi.App_Start.NinjectWebCommon), "Stop")]

namespace CompanyApi.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using CompanyApi.Domain.Repositories;
    using CompanyApi.Domain.Services;
    using CompanyApi.Persistence.Repositories;
    using CompanyApi.Services;
    using EmployeeApi.Services;
    using FreelanceApi.Services;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                //Suport WebAPI Injection
                GlobalConfiguration.Configuration.DependencyResolver = new WebApiContrib.IoC.Ninject.NinjectResolver(kernel);

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICompanyService>().To<CompanyService>().InSingletonScope();
            kernel.Bind<IEmployeeService>().To<EmployeeService>().InSingletonScope();
            kernel.Bind<IFreelanceService>().To<FreelanceService>().InSingletonScope();
            kernel.Bind<IAddressService>().To<AddressService>().InSingletonScope();

            kernel.Bind<ICompanyRepository>().To<CompanyRepository>().InSingletonScope();
            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>().InSingletonScope();
            kernel.Bind<IFreelanceRepository>().To<FreelanceRepository>().InSingletonScope();
            kernel.Bind<IAddressRepository>().To<AddressRepository>().InSingletonScope();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }        
    }
}