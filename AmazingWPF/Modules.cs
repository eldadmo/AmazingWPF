using AmazingWPF.Contracts.Entities;
using AmazingWPF.Contracts.Services;
using AmazingWPF.Screens;
using AmazingWPF.Services;
using AmazingWPF.ViewModels;
using Autofac;

namespace AmazingWPF
{
    public class Modules : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShellViewModel>().As<IShellViewModel>();
            builder.RegisterType<MainViewModel>().As<IMainViewModel>();

            //Services - Best practice is to separate services to other dll, but it will do for now
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
        }
    }
}