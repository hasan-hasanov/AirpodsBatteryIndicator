using ABI.Common;
using ABI.Model.Entities;
using ABI.ViewModel.BleParsers;
using ABI.ViewModel.Jobs;
using System;
using System.Threading;

namespace ABI.ViewModel.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly AirpodsBleParser _airpodsBleParser;
        private readonly BleScannerJob _bleScannerJob;

        public Action<Action> RunOnUIThread { get; set; }

        private string leftEarbudsBatteryLevel;
        public string LeftEarbudsBatteryLevel
        {
            get
            {
                return leftEarbudsBatteryLevel;
            }
            set
            {
                leftEarbudsBatteryLevel = value;
                RaisePropertyChanged(nameof(LeftEarbudsBatteryLevel));
            }
        }

        private string rightEarbudsBatteryLevel;
        public string RightEarbudsBatterylevel
        {
            get
            {
                return rightEarbudsBatteryLevel;
            }
            set
            {
                rightEarbudsBatteryLevel = value;
                RaisePropertyChanged(nameof(RightEarbudsBatterylevel));
            }
        }

        private string caseBatteryLevel;
        public string CaseBatterylevel
        {
            get
            {
                return caseBatteryLevel;
            }
            set
            {
                caseBatteryLevel = value;
                RaisePropertyChanged(nameof(CaseBatterylevel));
            }
        }

        public MainViewModel(AirpodsBleParser airpodsBleParser)
        {
            _airpodsBleParser = airpodsBleParser;
            _bleScannerJob = new BleScannerJob(new Action<char[]>(OnBleStatusChanged));
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
                RunOnUIThread(() => LeftEarbudsBatteryLevel = airpodsInfo.LeftEarbudStatus == -1 ? AppleConstants.NotAvailable : airpodsInfo.LeftEarbudStatus.ToString());
                RunOnUIThread(() => RightEarbudsBatterylevel = airpodsInfo.RightEarbudStatus == -1 ? AppleConstants.NotAvailable : airpodsInfo.RightEarbudStatus.ToString());
                RunOnUIThread(() => CaseBatterylevel = airpodsInfo.CaseStatus == -1 ? AppleConstants.NotAvailable : airpodsInfo.CaseStatus.ToString());
            }
            else
            {
                LeftEarbudsBatteryLevel = AppleConstants.NotAvailable;
                RightEarbudsBatterylevel = AppleConstants.NotAvailable;
                CaseBatterylevel = AppleConstants.NotAvailable;
            }
        }
    }
}
