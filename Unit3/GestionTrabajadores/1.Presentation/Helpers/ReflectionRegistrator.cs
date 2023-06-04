using Autofac;
using GestionTrabajadores._2.Bussiness;
using GestionTrabajadores._3.Domain.IRepositories;
using GestionTrabajadores.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores._1.Presentation.Helpers
{
    public class ReflectionRegistrator
    {
        public IContainer RegisterDependencies()
        {
            var containerBuilder = new ContainerBuilder();

            RegisterCustomDependencies(containerBuilder);
            var container = containerBuilder.Build();
            return container;
        }
        private void RegisterCustomDependencies(ContainerBuilder containerBuilder) 
        {
            containerBuilder.RegisterType<IDeletes>().As<Deletes>();
            containerBuilder.RegisterType<IRepositoryITWorker>().As<ITWorker>();
            containerBuilder.RegisterType<IRepositoryTask>().As<Task>();
            containerBuilder.RegisterType<IRepositoryTeam>().As<Team>();
            containerBuilder.RegisterType<ILogin>().As<Login>();
        }
    }
}
