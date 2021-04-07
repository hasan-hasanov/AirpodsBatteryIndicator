using ABI.Adapter.NamedPipe.Queries.GetAirpodsBatteryStatus;
using ABI.Core.Entities;
using ABI.Core.Queries;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirpodsBatteryIndicator
{
    public partial class MainForm : Form
    {
        private readonly IQueryHandler<GetAirpodsBatteryStatusQuery, BatteryIndicator> _getAirpodsBatteryStatusQueryHandler;

        private Task _airpodsTimerOperation;

        public MainForm(IQueryHandler<GetAirpodsBatteryStatusQuery, BatteryIndicator> getAirpodsBatteryStatusQueryHandler)
        {
            InitializeComponent();

            _getAirpodsBatteryStatusQueryHandler = getAirpodsBatteryStatusQueryHandler;

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("Open", null, (sender, e) =>
            {
                Show();
                this.WindowState = FormWindowState.Normal;
            });
            contextMenuStrip.Items.Add("Exit", null, (sender, e) =>
            {
                Application.Exit();
            });

            trayControl.ContextMenuStrip = contextMenuStrip;
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
                this.WindowState = FormWindowState.Minimized;
                Hide();
            }
        }

        private async Task FetchAirpodsBatteryStatus()
        {
            try
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMinutes(1));
                BatteryIndicator airpods = await _getAirpodsBatteryStatusQueryHandler.HandleAsync(new GetAirpodsBatteryStatusQuery(), cancellationTokenSource.Token);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(airpods.LeftEarbud < 0 ? "Left: N/A" : $"Left: {airpods.LeftEarbud} %")
                    .AppendLine(airpods.RightEarbud < 0 ? "Right: N/A" : $"Right: {airpods.RightEarbud} %")
                    .AppendLine(airpods.Case < 0 ? "Case: N/A" : $"Case: {airpods.Case} %");

                trayControl.Text = sb.ToString();

                labelLeftBud.Text = airpods.LeftEarbud < 0 ? "Not connected" : $"{airpods.LeftEarbud} %";
                labelRightBud.Text = airpods.RightEarbud < 0 ? "Not connected" : $"{airpods.RightEarbud} %";
                labelCase.Text = airpods.Case < 0 ? "Not connected" : $"{airpods.Case} %";
            }
            catch (Exception ex)
            {
                // TODO: Once ensured it works properly on production make a better error handler.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void TrayControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                this.WindowState = FormWindowState.Normal;
            }
        }
    }
}
