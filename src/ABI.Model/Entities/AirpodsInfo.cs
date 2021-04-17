namespace ABI.Model.Entities
{
    public class AirpodsInfo
    {
        public int LeftEarbudStatus { get; set; }

        public int RightEarbudStatus { get; set; }

        public int CaseStatus { get; set; }

        public bool IsLeftEarbudCharging { get; set; }

        public bool IsRightEarbudCharging { get; set; }

        public bool IsCaseCharging { get; set; }

        public bool IsLeftEarbudInEar { get; set; }

        public bool IsRightEarbudInEar { get; set; }

        public string Model { get; set; }
    }
}
