﻿using ABI.ViewModel.ViewModels;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ABI.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            InitializeMvvm(mainViewModel);

            this.DataContext = mainViewModel;

            // Position the window to the bottom right of the screen
            Left = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            Top = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
        }

        private void InitializeMvvm(MainViewModel mainViewModel)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1),
                IsEnabled = true
            };

            dispatcherTimer.Tick += (s, e) => mainViewModel.StartBackgroundJob();
            dispatcherTimer.Start();

            mainViewModel.ExitAction = () => Dispatcher.Invoke(() => Close());
            mainViewModel.MinimizeAction = () => Dispatcher.Invoke(() => WindowState = WindowState.Minimized);
            mainViewModel.NormalizeAction = () => Dispatcher.Invoke(() => WindowState = WindowState.Normal);
        }
    }
}
