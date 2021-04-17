using ABI.Common.Enums;
using ABI.Model.AirpodModels;
using ABI.ViewModel.Commands;
using System;
using System.Windows.Input;

namespace ABI.ViewModel.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private AirpodsStatus _airpodsStatus;

        private string leftEarbudBattery;
        private string caseBattery;
        private string rightEarbudBattery;

        public MainViewModel()
        {
            _airpodsStatus = new AirpodsStatus();

            LeftEarbudBattery = _airpodsStatus.LeftEarbudBattery.ToString();
            CaseBattery = _airpodsStatus.CaseBattery.ToString();
            RightEarbudBattery = _airpodsStatus.RightEarbudBattery.ToString();


            OpenClickCommand = new RelayCommand<object>(e => OpenClick(), p => true);
            SettingsClickCommand = new RelayCommand<object>(e => SettingsClick(), p => true);
            ExitClickCommand = new RelayCommand<object>(e => ExitClick(), p => true);
            TrayIconClickCommand = new RelayCommand<WindowState>(e => ToggleMaximizeMinimize(e), p => true);
            TrayIconDoubleClickCommand = new RelayCommand<WindowState>(e => ToggleMaximizeMinimize(e), p => true);
        }

        public Action ExitAction { get; set; }
        public Action HideAction { get; set; }
        public Action ShowAction { get; set; }

        public ICommand OpenClickCommand { get; set; }
        public ICommand SettingsClickCommand { get; set; }
        public ICommand ExitClickCommand { get; set; }
        public ICommand TrayIconClickCommand { get; set; }
        public ICommand TrayIconDoubleClickCommand { get; set; }

        public string LeftEarbudBattery
        {
            get
            {
                return leftEarbudBattery;
            }
            set
            {
                if (leftEarbudBattery != value)
                {
                    leftEarbudBattery = (value == "-1") ? "N/A" : value;
                    RaisePropertyChanged(nameof(LeftEarbudBattery));
                }
            }
        }

        public string CaseBattery
        {
            get
            {
                return caseBattery;
            }
            set
            {
                if (caseBattery != value)
                {
                    caseBattery = (value == "-1") ? "N/A" : value;
                    RaisePropertyChanged(nameof(CaseBattery));
                }
            }
        }

        public string RightEarbudBattery
        {
            get
            {
                return rightEarbudBattery;
            }
            set
            {
                if (rightEarbudBattery != value)
                {
                    rightEarbudBattery = (value == "-1") ? "N/A" : value;
                    RaisePropertyChanged(nameof(RightEarbudBattery));
                }
            }
        }

        public void Loaded()
        {
        }

        public void ToggleMaximizeMinimize(WindowState state)
        {
        }

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
