﻿using System.Configuration;
using Ninject.Web.Common.WebHost;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(fromplaytobow.co.uk.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(fromplaytobow.co.uk.App_Start.NinjectWebCommon), "Stop")]

namespace fromplaytobow.co.uk.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using FPTB.Services.Infrastructure;
    using FPTB.Services.Implementation;
    using FPTB.Data.Repositories.Infrastructure;
    using FPTB.Data.Repositories.Implementation;
    using System.Data.Entity;
    using FPTB.Data;
    using System.Data.Common;
    using Authentication.Infrastructure;
    using Authentication.Implementation;

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
            var serverId = CM.Security.Decrypt(ConfigurationManager.AppSettings["ServerId"]);
            var apiKey = CM.Security.Decrypt(ConfigurationManager.AppSettings["ApiKey"]);

            kernel.Bind<IUnitOfWork>().To<GenericUnitOfWork>().WithConstructorArgument("dbContext", new FPTBContext());
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IHtmlPageService>().To<HtmlPageService>();
            kernel.Bind<IOAuthService>().To<OckAuthService>();
            kernel.Bind<IMessageService>().To<MessageService>();
            kernel.Bind<IEmailService>().To<SocketLabEmailService>()
                .WithConstructorArgument("serverId", Convert.ToInt32(serverId))
                .WithConstructorArgument("apiKey", apiKey); 
        }
    }
}
