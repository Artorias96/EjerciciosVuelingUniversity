using Autofac;
using CuentaBancariaMultiUsuario._1.Presentation.Helpers;
using CuentaBancariaMultiUsuario._1.Presentation.Screens;
using CuentaBancariaMultiUsuario._2.Business.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaMultiUsuario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = CreateContainer();
            var menuAccount = new MainMenuScreen(
                container.Resolve<IBankAccountService>());

            menuAccount.Start();

        }
        private static IContainer CreateContainer()
        {
            var registrator = new ReflectionRegistrator();
            var container = registrator.RegisterDependencies();
            return container;

        }
    }
}
