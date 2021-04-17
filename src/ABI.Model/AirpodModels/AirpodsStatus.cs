namespace ABI.Model.AirpodModels
{
    public class AirpodsStatus : BaseModel
    {
        private int leftEarbudBattery;
        private int rightEarbudBattery;
        private int caseBattery;

        public AirpodsStatus()
        {
            leftEarbudBattery = -1;
            rightEarbudBattery = -1;
            caseBattery = -1;
        }

        public bool IsAvailable => leftEarbudBattery != -1 || rightEarbudBattery != -1 || caseBattery != -1;

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

        public int CaseBattery
        {
            get { return caseBattery; }
            set
            {
                if (caseBattery != value)
                {
                    caseBattery = value;
                    RaisePropertyChanged(nameof(CaseBattery));
                }
            }
        }
    }
}
