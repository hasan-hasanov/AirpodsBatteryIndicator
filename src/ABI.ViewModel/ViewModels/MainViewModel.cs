using ABI.ViewModel.Commands;
using System.Windows.Input;

namespace ABI.ViewModel.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            LeftEarbudBattery = "90";

            OpenClickCommand = new RelayCommand(e => OpenClick(), p => true);
            SettingsClickCommand = new RelayCommand(e => SettingsClick(), p => true);
            ExitClickCommand = new RelayCommand(e => ExitClick(), p => true);
        }

        public string LeftEarbudBattery { get; set; }

        public ICommand OpenClickCommand { get; set; }

        public ICommand SettingsClickCommand { get; set; }

        public ICommand ExitClickCommand { get; set; }

        public void OpenClick()
        {

        }

        public void SettingsClick()
        {

        }

        public void ExitClick()
        {

        }
    }
}
