using Microsoft.Extensions.DependencyInjection;
using EmployeesManagement.ViewModel;
using EmployeesManagement.Services;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace EmployeesManagement
{
    public partial class App : Application
    {
        private static IHost _Host;
        public static IHost Host => _Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static bool IsDesignMode { get; private set; } = true;
        protected async override void OnStartup(StartupEventArgs e)
        {
            IsDesignMode = false;
            var host = Host;
            await host.StartAsync().ConfigureAwait(false);
            base.OnStartup(e);
        }
        protected async override void OnExit(ExitEventArgs e)
        {
            var host = Host;
            await Host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            _Host = null;
            base.OnExit(e);
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .RegisterServices()
            .RegistratorViewModels();
       
        public static string CurrentDirectory => IsDesignMode
            ? Path.GetDirectoryName(GetSourceCodePath())
            : Environment.CurrentDirectory;
        private static string GetSourceCodePath([CallerFilePath] string Path = null) => Path;
    }
}
