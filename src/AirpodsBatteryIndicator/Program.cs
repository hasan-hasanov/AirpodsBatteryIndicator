using ABI.Services.Configurations;
using ABI.Services.Presenters;
using ABI.Services.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace AirpodsBatteryIndicator
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServiceCollection services = new ServiceCollection();

            services.AddScoped<MainForm>();
            services.AddScoped<IMainView, MainForm>(services => services.GetService<MainForm>());
            services.AddScoped<MainPresenter>();

            services.RegisterTypes();

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                mainForm.Tag = serviceProvider.GetRequiredService<MainPresenter>();
                Application.Run(mainForm);
            }
        }
    }
}
