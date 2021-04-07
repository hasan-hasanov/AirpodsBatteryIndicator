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
            var status = await _getAirpodsBatteryStatusQueryHandler.HandleAsync(new GetAirpodsBatteryStatusQuery());
            _view.BatteryIndicator = $"{status.LeftEarbud}";
        }
    }
}
