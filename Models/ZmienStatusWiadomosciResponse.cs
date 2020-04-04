using System;
using System.Collections.Generic;
using System.Text;

namespace UONETAutoRead.Models
{
    public class ZmienStatusWiadomosciResponse
    {
        public string Status { get; set; }
        public int TimeKey { get; set; }
        public string TimeValue { get; set; }
        public string RequestId { get; set; }
        public int DayOfWeek { get; set; }
        public string AppVersion { get; set; }
        public string Data { get; set; }
    }
}
