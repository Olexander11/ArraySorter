using Autofac;
using CommonInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ArraySorter.DllLoader
{
    internal static class DllDirectoryLoader
    {
        public static ISorter[] LoadSorters()
        {
            try
            {
                IContainer container = GetContainer();

                return container.Resolve<IEnumerable<ISorter>>().ToArray();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static IOrder[] LoadOrders()
        {
            try
            {
                IContainer container = GetContainer();

                return container.Resolve<IEnumerable<IOrder>>().ToArray();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static IContainer GetContainer()
        {
            var assemblies = new List<Assembly>();
            assemblies.AddRange(
                Directory.EnumerateFiles(ConfigurationManager.AppSettings["SortDirectory"], "*.dll", SearchOption.AllDirectories)
                                 .Select(Assembly.LoadFrom));

            var builder = new ContainerBuilder();
            foreach (Assembly assembly in assemblies)
            {
                builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            }

           return builder.Build();
        }

    }
}
