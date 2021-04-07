using ABI.Adapter.NamedPipe.Queries.GetAirpodsBatteryStatus;
using ABI.Core.Entities;
using ABI.Core.Queries;
using System;
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
        }

        private void AirpodsBatteryCheckTimer_Tick(object sender, EventArgs e)
        {
            if (_airpodsTimerOperation == null || _airpodsTimerOperation.IsCompleted)
            {
                _airpodsTimerOperation = FetchAirpodsBatteryStatus();
            }
        }

        private async Task FetchAirpodsBatteryStatus()
        {
            BatteryIndicator airpods = await _getAirpodsBatteryStatusQueryHandler.HandleAsync(new GetAirpodsBatteryStatusQuery());

            labelLeftBud.Text = airpods.LeftEarbud < 0 ? "Not connected" : $"{airpods.LeftEarbud} %";
            labelRightBud.Text = airpods.RightEarbud < 0 ? "Not connected" : $"{airpods.RightEarbud} %";
            labelCase.Text = airpods.Case < 0 ? "Not connected" : $"{airpods.Case} %";
        }
    }
}
