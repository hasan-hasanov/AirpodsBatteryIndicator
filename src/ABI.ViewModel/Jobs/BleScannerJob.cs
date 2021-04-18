using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Advertisement;

namespace ABI.ViewModel.Jobs
{
    public class BleScannerJob
    {
        private Task executingTask;
        private BluetoothLEAdvertisementWatcher watcher;
        private TaskCompletionSource<bool> taskCompletionSource;

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
                        taskCompletionSource.SetResult(false);
                    }
                });

                try
                {
                    watcher = new BluetoothLEAdvertisementWatcher();
                    watcher.Received += Watcher_Received;
                    watcher.Stopped += Watcher_Stopped;
                    watcher.ScanningMode = BluetoothLEScanningMode.Passive;
                    watcher.Start();

                    await taskCompletionSource.Task;
                }
                catch
                {
                    // TODO: Write these error to an aproppriate place
                }
                finally
                {
                    watcher.Received -= Watcher_Received;
                    watcher.Stopped -= Watcher_Stopped;
                    watcher.Stop();
                }
            }
        }

        private void Watcher_Stopped(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementWatcherStoppedEventArgs args)
        {
        }

        private void Watcher_Received(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {
            taskCompletionSource.SetResult(true);
        }
    }
}
