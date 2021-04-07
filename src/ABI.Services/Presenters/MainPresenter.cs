using ABI.Adapter.NamedPipe.Queries.GetAirpodsBatteryStatus;
using ABI.Core.Entities;
using ABI.Core.Queries;
using ABI.Services.Views;
using System;

namespace ABI.Services.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly IQueryHandler<GetAirpodsBatteryStatusQuery, BatteryIndicator> _getAirpodsBatteryStatusQueryHandler;

        public MainPresenter(
            IMainView mainView,
            IQueryHandler<GetAirpodsBatteryStatusQuery, BatteryIndicator> getAirpodsBatteryStatusQueryHandler)
        {
            _view = mainView;

            _getAirpodsBatteryStatusQueryHandler = getAirpodsBatteryStatusQueryHandler;

            mainView.Load += MainFormViewOnLoad;
        }

        private async void MainFormViewOnLoad(object sender, EventArgs eventArgs)
        {
            BatteryIndicator airpods = await _getAirpodsBatteryStatusQueryHandler.HandleAsync(new GetAirpodsBatteryStatusQuery());

            _view.LeftBudBatteryPercentage = airpods.LeftEarbud < 0 ? "Not connected" : $"{airpods.LeftEarbud} %";
            _view.RightBudBatteryPercentage = airpods.RightEarbud < 0 ? "Not connected" : $"{airpods.RightEarbud} %";
            _view.CaseBatteryPercentage = airpods.Case < 0 ? "Not connected" : $"{airpods.Case} %";
        }
    }
}
