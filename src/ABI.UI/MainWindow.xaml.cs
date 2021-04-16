using System.Windows;
using System.Windows.Forms;

namespace ABI.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Position the window to the bottom right of the screen
            Left = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            Top = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
        }
    }
}
