using Newtonsoft.Json;

namespace ABI.Core.Entities
{
    public class BatteryIndicator
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("rssi")]
        public int SignalRange { get; set; }

        [JsonProperty("addr")]
        public string DeviceAddress { get; set; }

        [JsonProperty("left")]
        public int LeftEarbud { get; set; }

        [JsonProperty("right")]
        public int RightEarbud { get; set; }

        [JsonProperty("case")]
        public int Case { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("charging_case")]
        public bool IsChargingCase { get; set; }

        [JsonProperty("charging_right")]
        public bool IsRightEarbudCharging { get; set; }

        [JsonProperty("charging_left")]
        public bool IsLeftEarbudCharging { get; set; }
    }
}
