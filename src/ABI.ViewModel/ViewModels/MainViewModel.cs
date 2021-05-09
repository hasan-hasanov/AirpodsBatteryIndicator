using ABI.Common.Enums;
using ABI.Model.Entities;
using ABI.Model.Models;
using ABI.ViewModel.AirpodsBle;
using ABI.ViewModel.Commands;
using ABI.ViewModel.Jobs;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows.Input;

namespace ABI.ViewModel.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly AirpodsBleParser _airpodsBleParser;
        private readonly ConcurrentDictionary<BatteryPercentStatus, Action> _changeTrayIcon;
        private readonly BleScannerJob _bleScannerJob;

        private bool isFirstTime = true;

        public MainViewModel(AirpodsBleParser airpodsBleParser)
        {
            _airpodsBleParser = airpodsBleParser;
            _changeTrayIcon = new ConcurrentDictionary<BatteryPercentStatus, Action>();
            _changeTrayIcon.TryAdd(BatteryPercentStatus.BatteryUndetermined, () => TrayIconDefault.Invoke());
            _changeTrayIcon.TryAdd(BatteryPercentStatus.Battery100Percent, () => TrayIcon100Percent());
            _changeTrayIcon.TryAdd(BatteryPercentStatus.Battery75Percent, () => TrayIcon75Percent());
            _changeTrayIcon.TryAdd(BatteryPercentStatus.Battery50Percent, () => TrayIcon50Percent());
            _changeTrayIcon.TryAdd(BatteryPercentStatus.Battery30Percent, () => TrayIcon30Percent());
            _changeTrayIcon.TryAdd(BatteryPercentStatus.Battery15Percent, () => TrayIcon15Percent());

            _bleScannerJob = new BleScannerJob(new Action<char[]>(OnBleStatusChanged));

            OpenClickCommand = new RelayCommand<object>(e => OpenClick(), p => true);
            SettingsClickCommand = new RelayCommand<object>(e => { }, p => true);
            ExitClickCommand = new RelayCommand<object>(e => ExitClick(), p => true);
            TrayIconClickCommand = new RelayCommand<WindowState>(e => ToggleNormalizeMinimize(e), p => true);
            TrayIconDoubleClickCommand = new RelayCommand<WindowState>(e => ToggleNormalizeMinimize(e), p => true);

            AirpodsInfo = new AirpodsInfoModel();
        }

        public ICommand OpenClickCommand { get; set; }
        public ICommand SettingsClickCommand { get; set; }
        public ICommand ExitClickCommand { get; set; }
        public ICommand TrayIconClickCommand { get; set; }
        public ICommand TrayIconDoubleClickCommand { get; set; }

        public Action ExitAction { get; set; }
        public Action MinimizeAction { get; set; }
        public Action NormalizeAction { get; set; }

        public Action TrayIconDefault { get; set; }
        public Action TrayIcon100Percent { get; set; }
        public Action TrayIcon75Percent { get; set; }
        public Action TrayIcon50Percent { get; set; }
        public Action TrayIcon30Percent { get; set; }
        public Action TrayIcon15Percent { get; set; }

        private AirpodsInfoModel airpodsInfoModel;
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

        public void MinimizeClick()
        {
            MinimizeAction();
        }

        public void ExitClick()
        {
            ExitAction();
        }

        public void StartBackgroundJob()
        {
            _bleScannerJob.ExecuteAsync(CancellationToken.None);
        }

        private void OnBleStatusChanged(char[] obj)
        {
            if (obj.Length > 0)
            {
                AirpodsInfo airpodsInfo = _airpodsBleParser.Parse(obj);
                AirpodsInfo = new AirpodsInfoModel(airpodsInfo);
                _changeTrayIcon[AirpodsInfo.BatteryStatus].Invoke();

                if (isFirstTime && AirpodsInfo.IsCaseOpen)
                {
                    isFirstTime = false;
                    NormalizeAction();
                }

                if (!AirpodsInfo.IsCaseOpen)
                {
                    isFirstTime = true;
                }
            }
            else
            {
                isFirstTime = true;
                AirpodsInfo = new AirpodsInfoModel();
                TrayIconDefault.Invoke();
            }
        }
    }
}
