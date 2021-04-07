using ABI.Services.Views;
using System.Windows.Forms;

namespace AirpodsBatteryIndicator
{
    public partial class MainForm : Form, IMainView
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public string BatteryIndicator { get => lblStatus.Text; set => lblStatus.Text = value; }
    }
}
