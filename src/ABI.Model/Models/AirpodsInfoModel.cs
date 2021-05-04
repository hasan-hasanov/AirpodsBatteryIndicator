using ABI.Model.Entities;
using System;

namespace ABI.Model.Models
{
    public class AirpodsInfoModel : BaseModel
    {
        private readonly AirpodsInfo airpods;

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
            airpods = airpodsInfo;

            CaseBattery = airpodsInfo.CaseStatus.ToString();
            LeftEarbudBattery = airpodsInfo.LeftEarbudStatus.ToString();
            RightEarbudBattery = airpodsInfo.RightEarbudStatus.ToString();
        }

        public bool IsAvailable => leftEarbudBattery != "-1" || rightEarbudBattery != "-1" || caseBattery != "-1";

        public int? MinBatteryPercent
        {
            get
            {
                if (IsAvailable)
                {
                    int minPercentage = Math.Max(Math.Max(airpods.CaseStatus, airpods.RightEarbudStatus), airpods.LeftEarbudStatus);
                    if (airpods.LeftEarbudStatus > 0 && airpods.LeftEarbudStatus < minPercentage)
                    {
                        minPercentage = airpods.LeftEarbudStatus;
                    }

                    if (airpods.RightEarbudStatus > 0 && airpods.RightEarbudStatus < minPercentage)
                    {
                        minPercentage = airpods.RightEarbudStatus;
                    }

                    if (airpods.CaseStatus > 0 && airpods.CaseStatus < minPercentage)
                    {
                        minPercentage = airpods.RightEarbudStatus;
                    }

                    return minPercentage;
                }

                return null;
            }
        }

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
