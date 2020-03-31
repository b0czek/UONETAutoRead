using Newtonsoft.Json;

namespace UONETAutoRead.Models
{
    public class LogAppStartReponse
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("TimeKey")]
        public int TimeKey { get; set; }
        [JsonProperty("TimeValue")]
        public string TimeValue { get; set; }
        [JsonProperty("RequestId")]
        public string RequestId { get; set; }
        [JsonProperty("DayOfWeek")]
        public int DayOfWeek { get; set; }
        [JsonProperty("AppVersion")]
        public string AppVersion { get; set; }
        [JsonProperty("Data")]
        public string Data { get; set; }
    }
}
