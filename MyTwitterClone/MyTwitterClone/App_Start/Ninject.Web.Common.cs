[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DemoApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DemoApp.App_Start.NinjectWebCommon), "Stop")]

namespace DemoApp.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Mvc;
    using System.Web.Http;
    using Ninject.Web.Mvc;
    using Ninject.Web.Common.WebHost;
    //using Business =MyTwitterClone.Business;
    using Data=MyTwitterClone.Data;

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

                RegisterServices(kernel);

                NinjectDependencyResolver ninjectResolver = new NinjectDependencyResolver(kernel);
                DependencyResolver.SetResolver(ninjectResolver); //MVC

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
            kernel.Bind<Data.Interfaces.ITwitterClone>().To<Data.Repository.TwitterClone>();
            kernel.Bind<MyTwitterClone.Business.Interface.ITwitterClone>().To<MyTwitterClone.Business.Model.TwitterCloneModel>();
        }
    }
}