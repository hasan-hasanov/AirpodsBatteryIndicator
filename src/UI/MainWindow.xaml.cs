using ABI.ViewModel.ViewModels;
using Microsoft.UI.Xaml;
using System;
using System.Runtime.Versioning;

namespace UI
{
    public sealed partial class MainWindow : Window
    {
        [SupportedOSPlatform("windows")]
        public MainWindow(MainViewModel viewModel)
        {
            this.InitializeComponent();

            DispatcherTimer dispatcherTimer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            MainViewModel = viewModel;

            dispatcherTimer.Tick += (s, e) => MainViewModel.StartBackgroundJob();
            dispatcherTimer.Start();
        }

        public MainViewModel MainViewModel { get; }
    }
}
