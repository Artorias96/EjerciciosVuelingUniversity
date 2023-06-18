using Autofac.Integration.WebApi;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Business.ServiceImplementations;
using Business.ServiceContracts;
using Infrastructure.RepositoryImplementations;
using Business.RepositoryContracts;
using StockManager.WebApi.Helpers;

namespace StockManager.WebApi.App_Start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<StockManagementService>().As<IStockManagementService>();
            builder.RegisterType<StockManagementRepository>().As<IStockManagementRepository>();
            builder.RegisterType<ValidationHelper>().As<IValidationService>();


            //Set the dependency resolver to be Autofac.
            Container = builder.Build();

            return Container;
        }
    }
}