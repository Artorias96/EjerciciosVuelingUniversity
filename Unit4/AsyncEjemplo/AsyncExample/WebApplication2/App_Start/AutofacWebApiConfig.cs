using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using IContainer = Autofac.IContainer;

namespace WebApplication2.App_Start
{
    public class AutofacWebApiConfig
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

            //builder.RegisterType<RebeldService>().As<IRebeldService>();
            //builder.RegisterType<RebeldRepository>().As<IRebeldRepository>();


            //Set the dependency resolver to be Autofac.
            Container = builder.Build();

            return Container;
        }
    }
}