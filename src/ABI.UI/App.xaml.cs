using ABI.ViewModel.AirpodsBle;
using ABI.ViewModel.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace ABI.UI
{
    public partial class App : Application
    {
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
