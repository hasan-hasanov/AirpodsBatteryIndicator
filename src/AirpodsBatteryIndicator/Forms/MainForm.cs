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

        public string LeftBudBatteryPercentage { get => labelLeftBud.Text; set => labelLeftBud.Text = value; }

        public string RightBudBatteryPercentage { get => labelRightBud.Text; set => labelRightBud.Text = value; }

        public string CaseBatteryPercentage { get => labelCase.Text; set => labelCase.Text = value; }
    }
}
