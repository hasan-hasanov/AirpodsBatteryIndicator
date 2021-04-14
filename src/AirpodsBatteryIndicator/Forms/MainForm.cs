using ABI.Common.Constants;
using AirpodsBatteryIndicator.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Storage.Streams;

namespace AirpodsBatteryIndicator
{
    public partial class MainForm : Form
    {
        private Task _airpodsTimerOperation;
        private BluetoothLEAdvertisementWatcher _watcher;
        private TaskCompletionSource<bool> _taskCompletionSource;
        private BluetoothLEDevice _airpods;

        public MainForm()
        {
            InitializeComponent();

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("Open", null, (sender, e) =>
            {
                ShowWindow();
            });
            contextMenuStrip.Items.Add("Exit", null, (sender, e) =>
            {
                Application.Exit();
            });

            trayControl.ContextMenuStrip = contextMenuStrip;

            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
        }

        private void AirpodsBatteryCheckTimer_Tick(object sender, EventArgs e)
        {
            if (_airpodsTimerOperation == null || _airpodsTimerOperation.IsCompleted)
            {
                _airpodsTimerOperation = FetchAirpodsBatteryStatus();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
                HideWindow();
            }
        }

        private void TrayControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    ShowWindow();
                }
                else
                {
                    HideWindow();
                }
            }
        }

        private async Task FetchAirpodsBatteryStatus()
        {
            _taskCompletionSource = new TaskCompletionSource<bool>();
            using (CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(5)))
            {
                cts.Token.Register(() =>
                {
                    _watcher.Stop();
                    if (!_taskCompletionSource.Task.IsCompleted)
                    {
                        _taskCompletionSource.SetResult(false);
                    }
                });

                try
                {
                    _watcher = new BluetoothLEAdvertisementWatcher();
                    _watcher.Received += Watcher_Received;
                    _watcher.Stopped += Watcher_Stopped;
                    _watcher.ScanningMode = BluetoothLEScanningMode.Passive;
                    _watcher.Start();

                    await _taskCompletionSource.Task;
                }
                catch
                {
                    // TODO: Write these error to an aproppriate place
                }
                finally
                {
                    _watcher.Received -= Watcher_Received;
                    _watcher.Stop();
                }
            }
        }

        private void Watcher_Stopped(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementWatcherStoppedEventArgs args)
        {
            if (_airpods == null)
            {
                UpdateAirpodsBatteryLevel(new AirpodBleParser());
            }

            _airpods = null;
        }

        private async void Watcher_Received(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {
            var manufacturerData = args.Advertisement.ManufacturerData.ToList().FirstOrDefault(c => c.CompanyId == AppleConstants.CompanyId);
            if (manufacturerData != null)
            {
                var rawData = new byte[manufacturerData.Data.Length];
                if (manufacturerData.Data.Length == AppleConstants.ManufacturerDataLenght)
                {
                    // This is necesseary because otherwise BLE wathcer picks up my phone too.
                    // This filters the phone and picks only the airpods
                    BluetoothLEDevice device = await BluetoothLEDevice.FromBluetoothAddressAsync(args.BluetoothAddress);
                    if (device != null)
                    {
                        _airpods = device;

                        using (DataReader reader = DataReader.FromBuffer(manufacturerData.Data))
                        {
                            reader.ReadBytes(rawData);
                        }

                        char[] hex = BitConverter.ToString(rawData).Split("-").SelectMany(s => s).ToArray();
                        AirpodBleParser airpodsBle = new AirpodBleParser(hex);

                        UpdateAirpodsBatteryLevel(airpodsBle);

                        if (!_taskCompletionSource.Task.IsCompleted)
                        {
                            _taskCompletionSource.SetResult(true);
                        }
                    }
                }
            }
        }

        private void UpdateAirpodsBatteryLevel(AirpodBleParser airpodsBle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(airpodsBle.LeftEarbudBatteryLevel < 0 ? "Left: N/A" : $"Left: {airpodsBle.LeftEarbudBatteryLevel} %")
                .AppendLine(airpodsBle.CaseBatteryLevel < 0 ? "Case: N/A" : $"Case: {airpodsBle.CaseBatteryLevel} %")
                .AppendLine(airpodsBle.RightEarbudBatteryLevel < 0 ? "Right: N/A" : $"Right: {airpodsBle.RightEarbudBatteryLevel} %");

            trayControl.Text = sb.ToString();

            this.Invoke((MethodInvoker)delegate
            {
                labelLeftBud.Text = airpodsBle.LeftEarbudBatteryLevel < 0 ? "N/A" : $"{airpodsBle.LeftEarbudBatteryLevel} %";
                labelCase.Text = airpodsBle.CaseBatteryLevel < 0 ? "N/A" : $"{airpodsBle.CaseBatteryLevel} %";
                labelRightBud.Text = airpodsBle.RightEarbudBatteryLevel < 0 ? "N/A" : $"{airpodsBle.RightEarbudBatteryLevel} %";
            });

            SetTryIconRegardingBattery(airpodsBle);
        }

        private void SetTryIconRegardingBattery(AirpodBleParser airpods)
        {
            if (airpods.IsConnected)
            {
                int minPercentage = airpods.CaseBatteryLevel;
                if (airpods.LeftEarbudBatteryLevel > 0)
                {
                    minPercentage = airpods.LeftEarbudBatteryLevel;
                }
                if (airpods.RightEarbudBatteryLevel > 0)
                {
                    minPercentage = airpods.RightEarbudBatteryLevel;
                }

                if (airpods.RightEarbudBatteryLevel > 0 && airpods.RightEarbudBatteryLevel < airpods.LeftEarbudBatteryLevel)
                {
                    minPercentage = airpods.RightEarbudBatteryLevel;
                }

                if (minPercentage > 75)
                {
                    trayControl.Icon = Resources._100_white;
                }
                else if (minPercentage > 50)
                {
                    trayControl.Icon = Resources._75_white;
                }
                else if (minPercentage > 30)
                {
                    trayControl.Icon = Resources._50_white;
                }
                else if (minPercentage > 15)
                {
                    trayControl.Icon = Resources._30_white;
                }
                else
                {
                    trayControl.Icon = Resources._15_white;
                }
            }
            else
            {
                trayControl.Icon = Resources.CaseWhiteBackground;
            }
        }

        private void ShowWindow()
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void HideWindow()
        {
            this.WindowState = FormWindowState.Minimized;
            Hide();
        }
    }
}
