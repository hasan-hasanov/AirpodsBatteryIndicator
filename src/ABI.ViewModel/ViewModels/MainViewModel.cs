using ABI.Common.Enums;
using ABI.Model.Models;
using ABI.ViewModel.Commands;
using System;
using System.Windows.Input;

namespace ABI.ViewModel.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private AirpodsInfoModel airpodsInfoModel;

        public MainViewModel()
        {
            AirpodsInfo = new AirpodsInfoModel();

            OpenClickCommand = new RelayCommand<object>(e => OpenClick(), p => true);
            SettingsClickCommand = new RelayCommand<object>(e => SettingsClick(), p => true);
            ExitClickCommand = new RelayCommand<object>(e => ExitClick(), p => true);
            TrayIconClickCommand = new RelayCommand<WindowState>(e => ToggleNormalizeMinimize(e), p => true);
            TrayIconDoubleClickCommand = new RelayCommand<WindowState>(e => ToggleNormalizeMinimize(e), p => true);
        }

        public Action ExitAction { get; set; }
        public Action MinimizeAction { get; set; }
        public Action NormalizeAction { get; set; }

        public ICommand OpenClickCommand { get; set; }
        public ICommand SettingsClickCommand { get; set; }
        public ICommand ExitClickCommand { get; set; }
        public ICommand TrayIconClickCommand { get; set; }
        public ICommand TrayIconDoubleClickCommand { get; set; }

        public AirpodsInfoModel AirpodsInfo
        {
            get
            {
                return airpodsInfoModel;
            }
            set
            {
                if (airpodsInfoModel != value)
                {
                    airpodsInfoModel = value;
                    RaisePropertyChanged(nameof(AirpodsInfo));
                }
            }
        }

        public void ToggleNormalizeMinimize(WindowState state)
        {
            if (state == WindowState.Normal || state == WindowState.Maximized)
            {
                MinimizeAction();
            }
            else
            {
                NormalizeAction();
            }
        }

        public void OpenClick()
        {
            NormalizeAction();
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
