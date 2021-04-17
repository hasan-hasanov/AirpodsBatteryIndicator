using System;

namespace ABI.UI
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            App application = new App();
            application.InitializeComponent();
            application.Run(new MainWindow());
        }
    }
}
