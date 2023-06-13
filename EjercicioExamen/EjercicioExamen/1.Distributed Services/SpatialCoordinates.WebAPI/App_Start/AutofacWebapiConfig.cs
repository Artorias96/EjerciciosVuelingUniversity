using Autofac;
using Autofac.Integration.WebApi;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.ServiceImplementations;
using System.Reflection;
using Infrastructure.RepositoryImplementations;
using System.Web;
using System.Web.Http;


namespace SpatialCoordinates.WebAPI.App_Start
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

            builder.RegisterType<CoordinatesService>().As<ICoordinatesService>();
            builder.RegisterType<CoordinatesRepository>().As<ICoordinatesRepository>();


            //Set the dependency resolver to be Autofac.
            Container = builder.Build();

            return Container;
        }
    }
}