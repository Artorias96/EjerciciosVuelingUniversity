using Autofac;
using CuentaBancariaMultiUsuario._2.Business;
using CuentaBancariaMultiUsuario._2.Business.IServices;
using CuentaBancariaMultiUsuario._3.Domain.IRepositories;
using CuentaBancariaMultiUsuario.Infrastructure_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario._1.Presentation.Helpers
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
            containerBuilder.RegisterType<BankAccountService>().As<IBankAccountService>();
            containerBuilder.RegisterType<BankAccountRepository>().As<IBankAccountRepository>();          
        }
    }
}
