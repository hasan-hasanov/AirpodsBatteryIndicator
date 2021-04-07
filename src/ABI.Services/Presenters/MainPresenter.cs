using ABI.Services.Views;
using System;

namespace ABI.Services.Presenters
{
    public class MainPresenter
    {
        public MainPresenter(IMainView mainView)
        {
            mainView.Load += MainFormViewOnLoad;
        }

        private void MainFormViewOnLoad(object sender, EventArgs eventArgs)
        {
        }
    }
}
