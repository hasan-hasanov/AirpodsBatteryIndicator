using ABI.ViewModel.AirpodsBle;
using ABI.ViewModel.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace ABI.UI
{
    public partial class App : Application
    {
        public App()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

#warning Remove this before release!!!
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/AirpodsErrors.txt";
            File.AppendAllLines(path, new string[] { e.ExceptionObject.ToString(), Environment.NewLine });
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<AreEarbudsFlippedParser>();
            services.AddSingleton<CaseParser>();
            services.AddSingleton<LeftEarbudParser>();
            services.AddSingleton<RightEarbudParser>();
            services.AddSingleton<AirpodsBleParser>();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();

            services.BuildServiceProvider().GetService<MainWindow>().Show();
        }
    }
}
