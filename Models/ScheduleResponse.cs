using Newtonsoft.Json;
using System.Collections.Generic;

namespace UONETAutoRead.Models
{
    public class ScheduleResponse
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
        public List<Lesson> Data { get; set; }
    }

    public class Lesson
    {
        [JsonProperty("Dzien")]
        public int Dzien { get; set; }
        [JsonProperty("DzienTekst")]
        public string DzienTekst { get; set; }
        [JsonProperty("NumerLekcji")]
        public int NumerLekcji { get; set; }
        [JsonProperty("IdPoraLekcji")]
        public int IdPoraLekcji { get; set; }
        [JsonProperty("IdPrzedmiot")]
        public int IdPrzedmiot { get; set; }
        [JsonProperty("PrzedmiotNazwa")]
        public string PrzedmiotNazwa { get; set; }
        [JsonProperty("PodzialSkrot")]
        public string PodzialSkrot { get; set; }
        [JsonProperty("Sala")]
        public string Sala { get; set; }
        [JsonProperty("IdPracownik")]
        public int IdPracownik { get; set; }
        [JsonProperty("IdPracownikWspomagajacy")]
        public object IdPracownikWspomagajacy { get; set; }
        [JsonProperty("IdPracownikWspomagajacy2")]
        public object IdPracownikWspomagajacy2 { get; set; }
        [JsonProperty("IdPracownikOld")]
        public object IdPracownikOld { get; set; }
        [JsonProperty("IdPracownikWspomagajacyOld")]
        public object IdPracownikWspomagajacyOld { get; set; }
        [JsonProperty("IdPracownikWspomagajacy2Old")]
        public object IdPracownikWspomagajacy2Old { get; set; }
        [JsonProperty("IdPlanLekcji")]
        public int IdPlanLekcji { get; set; }
        [JsonProperty("AdnotacjaOZmianie")]
        public string AdnotacjaOZmianie { get; set; }
        [JsonProperty("PrzekreslonaNazwa")]
        public bool PrzekreslonaNazwa { get; set; }
        [JsonProperty("PogrubionaNazwa")]
        public bool PogrubionaNazwa { get; set; }
        [JsonProperty("PlanUcznia")]
        public bool PlanUcznia { get; set; }
    }

}

