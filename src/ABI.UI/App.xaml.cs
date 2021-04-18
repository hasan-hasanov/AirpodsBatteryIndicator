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

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();

            services.BuildServiceProvider().GetService<MainWindow>().Show();
        }
    }
}
