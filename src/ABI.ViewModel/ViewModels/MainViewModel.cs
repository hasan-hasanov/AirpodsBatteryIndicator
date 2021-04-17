using ABI.Model.AirpodModels;
using ABI.ViewModel.Commands;
using System;
using System.Windows.Input;

namespace ABI.ViewModel.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private AirpodsStatus airpodsStatus;

        public MainViewModel()
        {
            airpodsStatus = new AirpodsStatus();

            AirpodsStatus.LeftEarbudBattery = 100;
            AirpodsStatus.CaseBattery = 100;
            AirpodsStatus.RightEarbudBattery = 100;

            OpenClickCommand = new RelayCommand<object>(e => OpenClick(), p => true);
            SettingsClickCommand = new RelayCommand<object>(e => SettingsClick(), p => true);
            ExitClickCommand = new RelayCommand<object>(e => ExitClick(), p => true);
        }

        public AirpodsStatus AirpodsStatus
        {
            get
            {
                return airpodsStatus;
            }
            set
            {
                if (airpodsStatus != value)
                {
                    airpodsStatus = value;
                    RaisePropertyChanged(nameof(AirpodsStatus));
                }
            }
        }

        public Action ExitAction { get; set; }
        public Action HideAction { get; set; }
        public Action ShowAction { get; set; }

        public ICommand OpenClickCommand { get; set; }
        public ICommand SettingsClickCommand { get; set; }
        public ICommand ExitClickCommand { get; set; }

        public void OpenClick()
        {
            ShowAction();
        }

        public void SettingsClick()
        {

        }

        public void ExitClick()
        {
            ExitAction();
        }
    }
}
