using Autofac;
using CommonInterfaces;
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
            List<Assembly> assemblies = new List<Assembly>();

            assemblies.AddRange(
                Directory.EnumerateFiles(ConfigurationManager.AppSettings["SortDirectory"], "*.dll", SearchOption.AllDirectories)
                                 .Select(Assembly.LoadFrom));

            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(assemblies.ToArray()).AsImplementedInterfaces();
            IContainer container = builder.Build();
            return container;
        }

    }
}
