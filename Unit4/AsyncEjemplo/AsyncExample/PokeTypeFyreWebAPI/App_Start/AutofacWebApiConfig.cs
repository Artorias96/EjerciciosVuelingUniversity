using Autofac.Integration.WebApi;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Business.ServiceImplementations;
using Infrastructure.RepositoryImplementations;
using Business.ServiceContracts;
using Domain.RepositoryContracts;

namespace PokeTypeFyreWebAPI.App_Start
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

            builder.RegisterType<PokeFyreService>().As<IPokeFyreService>();
            builder.RegisterType<PokeFyreRepository>().As<IPokeFyreRepository>();


            //Set the dependency resolver to be Autofac.
            Container = builder.Build();

            return Container;
        }
    }
}