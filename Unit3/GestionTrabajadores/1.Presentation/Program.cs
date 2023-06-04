using Autofac;
using GestionTrabajadores._1.Presentation.Helpers;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTrabajadores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = CreateContainer();
            //var menuManagement = new MenuAdmin();

        }

        private static IContainer CreateContainer()
        {
            var registrator = new ReflectionRegistrator();
            var container = registrator.RegisterDependencies();
            return container;
        }
    }
}
