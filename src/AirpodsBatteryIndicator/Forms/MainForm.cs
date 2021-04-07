using ABI.Adapter.NamedPipe.Queries.GetAirpodsBatteryStatus;
using ABI.Core.Entities;
using ABI.Core.Queries;
using AirpodsBatteryIndicator.Properties;
using System;
using System.Drawing;
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
            if (_airpodsTimerOperation == null)
            {
                SimulateAnimation(labelLeftBud);
                SimulateAnimation(labelCase);
                SimulateAnimation(labelRightBud);
            }

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
            try
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMinutes(1));
                BatteryIndicator airpods = await _getAirpodsBatteryStatusQueryHandler.HandleAsync(new GetAirpodsBatteryStatusQuery(), cancellationTokenSource.Token);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(airpods.LeftEarbud < 0 ? "Left: N/A" : $"Left: {airpods.LeftEarbud} %")
                    .AppendLine(airpods.Case < 0 ? "Case: N/A" : $"Case: {airpods.Case} %")
                    .AppendLine(airpods.RightEarbud < 0 ? "Right: N/A" : $"Right: {airpods.RightEarbud} %");

                trayControl.Text = sb.ToString();

                labelLeftBud.Text = airpods.LeftEarbud < 0 ? "N/A" : $"{airpods.LeftEarbud} %";
                labelCase.Text = airpods.Case < 0 ? "N/A" : $"{airpods.Case} %";
                labelRightBud.Text = airpods.RightEarbud < 0 ? "N/A" : $"{airpods.RightEarbud} %";

                SetTryIconRegardingBattery(airpods);
            }
            catch (Exception ex)
            {
                // TODO: Once ensured it works properly on production make a better error handler.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void SetTryIconRegardingBattery(BatteryIndicator airpods)
        {
            if (airpods.Status == 1)
            {
                int minPercentage = airpods.Case;
                if (airpods.LeftEarbud > 0)
                {
                    minPercentage = airpods.LeftEarbud;
                }
                if (airpods.RightEarbud > 0)
                {
                    minPercentage = airpods.RightEarbud;
                }

                if (airpods.RightEarbud > 0 && airpods.RightEarbud < airpods.LeftEarbud)
                {
                    minPercentage = airpods.RightEarbud;
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

        private void SimulateAnimation(Button button)
        {
            button.Text = button.Text += ".";
            if (button.Text.Length >= 3)
            {
                button.Text = ".";
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
