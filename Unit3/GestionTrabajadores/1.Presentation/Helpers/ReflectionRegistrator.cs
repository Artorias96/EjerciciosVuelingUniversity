using Autofac;
using GestionTrabajadores._2.Bussiness;
using GestionTrabajadores._2.Bussiness.Contracts;
using GestionTrabajadores._3.Domain.IRepositories;
using GestionTrabajadores._3.Domain.Repositories;
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
            containerBuilder.RegisterType<Deletes>().As<IDeletes>();
            containerBuilder.RegisterType<RepositoryITWorker>().As<IRepositoryITWorker>();
            containerBuilder.RegisterType<RepositoryTask>().As<IRepositoryTask>();
            containerBuilder.RegisterType<RepositoryTeam>().As<IRepositoryTeam>();
            containerBuilder.RegisterType<Login>().As<ILogin>();
            containerBuilder.RegisterType<MenuAdminService>().As<IMenuAdminService>();
        }
    }
}
