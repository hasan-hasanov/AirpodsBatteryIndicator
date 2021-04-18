using ABI.Common.Constants;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Storage.Streams;

namespace ABI.ViewModel.Jobs
{
    public class BleScannerJob
    {
        private readonly Action<char[]> _onBleStatusChanged;

        private Task executingTask;
        private BluetoothLEAdvertisementWatcher watcher;
        private TaskCompletionSource<bool> taskCompletionSource;

        public BleScannerJob(Action<char[]> onBleFound)
        {
            _onBleStatusChanged = onBleFound;
        }

        public Task ExecuteAsync(CancellationToken cancellationToken)
        {
            if (executingTask == null || executingTask.IsCompleted)
            {
                executingTask = ScanForBleDevices();
            }

            return Task.CompletedTask;
        }

        private async Task ScanForBleDevices()
        {
            taskCompletionSource = new TaskCompletionSource<bool>();
            using (CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(5)))
            {
                cts.Token.Register(() =>
                {
                    watcher.Stop();
                    if (!taskCompletionSource.Task.IsCompleted)
                    {
                        taskCompletionSource.SetCanceled();
                    }
                });

                try
                {
                    watcher = new BluetoothLEAdvertisementWatcher()
                    {
                        ScanningMode = BluetoothLEScanningMode.Passive
                    };

                    watcher.Received += Watcher_Received;
                    watcher.Start();

                    await taskCompletionSource.Task;
                }
                catch
                {
                    _onBleStatusChanged(new char[] { });
                }
                finally
                {
                    watcher.Received -= Watcher_Received;
                    watcher.Stop();
                }
            }
        }

        private async void Watcher_Received(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {
            var manufacturerData = args.Advertisement.ManufacturerData.ToList().FirstOrDefault(c => c.CompanyId == AppleConstants.CompanyId);
            if (manufacturerData == null)
            {
                return;
            }

            var rawData = new byte[manufacturerData.Data.Length];
            if (manufacturerData.Data.Length != AppleConstants.ManufacturerDataLenght)
            {
                return;
            }

            if (await BluetoothLEDevice.FromBluetoothAddressAsync(args.BluetoothAddress) == null)
            {
                return;
            }

            using DataReader reader = DataReader.FromBuffer(manufacturerData.Data);
            reader.ReadBytes(rawData);

            char[] airpodsInfoHex = BitConverter.ToString(rawData).Split("-").SelectMany(s => s).ToArray();
            _onBleStatusChanged.Invoke(airpodsInfoHex);

            if (!taskCompletionSource.Task.IsCompleted)
            {
                taskCompletionSource.SetResult(true);
            }
        }
    }
}
