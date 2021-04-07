using System;

namespace ABI.Services.Views
{
    public interface IMainView
    {
        event EventHandler Load;

        string BatteryIndicator { get; set; }
    }
}
