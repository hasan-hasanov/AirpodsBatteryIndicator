using ABI.ViewModel.ViewModels;
using Microsoft.UI.Xaml;

namespace UI
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            this.InitializeComponent();

            MainViewModel = viewModel;
        }

        public MainViewModel MainViewModel { get; }
    }
}
