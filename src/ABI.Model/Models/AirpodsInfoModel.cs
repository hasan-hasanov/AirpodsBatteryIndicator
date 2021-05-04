using ABI.Model.Entities;

namespace ABI.Model.Models
{
    public class AirpodsInfoModel : BaseModel
    {
        private string leftEarbudBattery;
        private string rightEarbudBattery;
        private string caseBattery;

        public AirpodsInfoModel()
        {
            LeftEarbudBattery = "-1";
            RightEarbudBattery = "-1";
            CaseBattery = "-1";
        }

        public AirpodsInfoModel(AirpodsInfo airpodsInfo)
        {
            CaseBattery = airpodsInfo.CaseStatus.ToString();
            LeftEarbudBattery = airpodsInfo.LeftEarbudStatus.ToString();
            RightEarbudBattery = airpodsInfo.RightEarbudStatus.ToString();
        }

        public bool IsAvailable => leftEarbudBattery != "-1" || rightEarbudBattery != "-1" || caseBattery != "-1";

        public string LeftEarbudBattery
        {
            get { return leftEarbudBattery; }
            set
            {
                if (leftEarbudBattery != value)
                {
                    leftEarbudBattery = (value == "-1") ? "N/A" : value;
                    RaisePropertyChanged(nameof(LeftEarbudBattery));
                }
            }
        }

        public string RightEarbudBattery
        {
            get { return rightEarbudBattery; }
            set
            {
                if (rightEarbudBattery != value)
                {
                    rightEarbudBattery = (value == "-1") ? "N/A" : value;
                    RaisePropertyChanged(nameof(RightEarbudBattery));
                }
            }
        }

        public string CaseBattery
        {
            get { return caseBattery; }
            set
            {
                if (caseBattery != value)
                {
                    caseBattery = (value == "-1") ? "N/A" : value;
                    RaisePropertyChanged(nameof(CaseBattery));
                }
            }
        }
    }
}
