using ABI.ViewModel.Screens;
using ABI.ViewModel.ViewModels;
using System;
using System.Windows;
using System.Windows.Forms;

namespace ABI.UI
{
    public partial class MainWindow : Window, IMainScreen
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
            Loaded += (s, e) => mainViewModel.Loaded();

            mainViewModel.ExitAction = new Action(Close);
            mainViewModel.MinimizeAction = () => WindowState = WindowState.Minimized;
            mainViewModel.NormalizeAction = () => WindowState = WindowState.Normal;
        }
    }
}
