namespace ABI.Model.AirpodModels
{
    public class AirpodsStatus : BaseModel
    {
        private int leftEarbudBattery;
        private int rightEarbudBattery;
        private int caseBatteryLevel;

        public bool IsAvailable => leftEarbudBattery != -1 || rightEarbudBattery != -1 || caseBatteryLevel != -1;

        public int LeftEarbudBattery
        {
            get { return leftEarbudBattery; }
            set
            {
                if (leftEarbudBattery != value)
                {
                    leftEarbudBattery = value;
                    RaisePropertyChanged(nameof(LeftEarbudBattery));
                }
            }
        }

        public int RightEarbudBattery
        {
            get { return rightEarbudBattery; }
            set
            {
                if (rightEarbudBattery != value)
                {
                    rightEarbudBattery = value;
                    RaisePropertyChanged(nameof(RightEarbudBattery));
                }
            }
        }

        public int CaseBatteryLevel
        {
            get { return caseBatteryLevel; }
            set
            {
                if (caseBatteryLevel != value)
                {
                    caseBatteryLevel = value;
                    RaisePropertyChanged(nameof(CaseBatteryLevel));
                }
            }
        }
    }
}
