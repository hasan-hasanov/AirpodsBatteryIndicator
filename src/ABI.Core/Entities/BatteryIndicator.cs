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
        public int Rssi { get; set; }

        [JsonProperty("addr")]
        public string Addr { get; set; }

        [JsonProperty("left")]
        public int Left { get; set; }

        [JsonProperty("right")]
        public int Right { get; set; }

        [JsonProperty("case")]
        public int Case { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("charging_case")]
        public bool ChargingCase { get; set; }

        [JsonProperty("charging_right")]
        public bool ChargingRight { get; set; }

        [JsonProperty("charging_left")]
        public bool ChargingLeft { get; set; }
    }
}
