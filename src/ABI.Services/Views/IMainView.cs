using System;

namespace ABI.Services.Views
{
    public interface IMainView
    {
        event EventHandler Load;

        string LeftBudBatteryPercentage { get; set; }

        string RightBudBatteryPercentage { get; set; }

        string CaseBatteryPercentage { get; set; }
    }
}
