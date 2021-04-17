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
            mainViewModel.ExitAction = new Action(this.Close);
            mainViewModel.HideAction = new Action(this.Hide);
            mainViewModel.ShowAction = new Action(this.Show);
        }
    }
}
