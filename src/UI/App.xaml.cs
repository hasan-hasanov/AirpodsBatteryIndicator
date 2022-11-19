using ABI.ViewModel.BleParsers;
using ABI.ViewModel.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

namespace UI
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<AreEarbudsFlippedParser>();
            services.AddSingleton<CaseParser>();
            services.AddSingleton<LeftEarbudParser>();
            services.AddSingleton<RightEarbudParser>();
            services.AddSingleton<AirpodsBleParser>();

            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();

            m_window = services.BuildServiceProvider().GetService<MainWindow>();
            m_window.Activate();
        }

        private Window m_window;
    }
}
