using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using AmazingWPF.Screens;
using Autofac;
using Caliburn.Micro;

namespace AmazingWPF
{
    public class Bootstrapper : BootstrapperBase
    {
        private static readonly string ModuleFilePrefix = Assembly.GetCallingAssembly().GetName().Name;

        private IContainer m_container;

        protected override void Configure()
        {
            base.Configure();

            var builder = new ContainerBuilder();

            RegisterTypes(builder);
            RegisterModule(builder);
            m_container = builder.Build();
        }

        private void RegisterModule(ContainerBuilder builder)
        {
            builder.RegisterModule<Modules>();
            //builder.RegisterModule<Services.Module>();
            //builder.RegisterModule<Managers.Module>();
        }


        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<WindowManager>().As<IWindowManager>().SingleInstance();
        }


        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IShellViewModel>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return GetAllDllEntries().Select(Assembly.LoadFrom);
        }

        protected override void BuildUp(object instance)
        {
            m_container.InjectProperties(instance);
        }

        protected override object GetInstance(Type service, string key)
        {
            return key == null ? m_container.Resolve(service) : m_container.ResolveKeyed(key, service);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            var enumerableOfServiceType = typeof(IEnumerable<>).MakeGenericType(service);
            return (IEnumerable<object>)m_container.Resolve(enumerableOfServiceType);
        }

        private static string[] GetAllDllEntries()
        {
            var runtimeDir = AppDomain.CurrentDomain.BaseDirectory;
            var files = Directory.GetFiles(runtimeDir).Where(file => Regex.IsMatch(file, @"^.+\.(exe|dll)$")).Where(x =>
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(x);
                return fileNameWithoutExtension.StartsWith(ModuleFilePrefix, StringComparison.Ordinal);
            }).ToArray();

            return files;
        }
    }
}