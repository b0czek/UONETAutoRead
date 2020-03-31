using Newtonsoft.Json;
using System.Collections.Generic;

namespace UONETAutoRead.Models
{
    public class ListaUczniowResponse
    {
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("TimeKey")]
        public long TimeKey { get; set; }
        [JsonProperty("TimeValue")]
        public string TimeValue { get; set; }
        [JsonProperty("RequestId")]
        public string RequestId { get; set; }
        [JsonProperty("DayOfWeek")]
        public int DayOfWeek { get; set; }
        [JsonProperty("AppVersion")]
        public string AppVersion { get; set; }
        [JsonProperty("Data")]
        public List<ListaUczniowData> Data { get; set; }
    }
    public class ListaUczniowData
    {
        [JsonProperty("IdOkresKlasyfikacjny")]
        public int IdOkresKlasyfikacjny { get; set; }
        [JsonProperty("OkresPoziom")]
        public int OkresPozion { get; set; }
        [JsonProperty("OkresNumer")]
        public int OkresNumber { get; set; }
        [JsonProperty("OkresDataOd")]
        public long OkresDataOd { get; set; }
        [JsonProperty("OkresDataDo")]
        public long OkresDataDo { get; set; }
        [JsonProperty("OkresDataOdTekst")]
        public string OkresDataOdTekst { get; set; }
        [JsonProperty("OkresDataDoTekst")]
        public string OkresDataDoTekst { get; set; }
        [JsonProperty("IdJednostkaSprawozdawcza")]
        public int IdJednostkaSprawozdawcza { get; set; }
        [JsonProperty("JednostkaSprawozdawczaSkrot")]
        public string JednostkaSprawozdawczaSkrot { get; set; }
        [JsonProperty("JednostkaSprawozdawczaNazwa")]
        public string JednostkaSprawozdawczaNazwa { get; set; }
        [JsonProperty("JednostkaSprawozdawczaSymbol")]
        public string JednostkaSprawozdawczaSymbol { get; set; }
        [JsonProperty("IdJednostka")]
        public int IdJednostka { get; set; }
        [JsonProperty("JednostkaNazwa")]
        public string JednostkaNazwa { get; set; }
        [JsonProperty("JednostkaSkrot")]
        public string JednostkaSkrot { get; set; }
        [JsonProperty("OddzialSymbol")]
        public string OddzialSymbol { get; set; }
        [JsonProperty("OddzialKod")]
        public string OddzialKod { get; set; }
        [JsonProperty("UzytkownikRola")]
        public string UzytkownikRola { get; set; }
        [JsonProperty("UzytkownikLogin")]
        public string UzytkownikLogin { get; set; }
        [JsonProperty("UzytkownikLoginId")]
        public int UzytkownikLoginId { get; set; }
        [JsonProperty("UzytkownikNazwa")]
        public string UzytkownikNazwa { get; set; }
        [JsonProperty("Przedszkolak")]
        public bool Przedszkolak { get; set; }
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("IdOddzial")]
        public int IdOddzial { get; set; }
        [JsonProperty("Imie")]
        public string Imie { get; set; }
        [JsonProperty("Imie2")]
        public string Imie2 { get; set; }
        [JsonProperty("Nazwisko")]
        public string Nazwisko { get; set; }
        [JsonProperty("Pseudonim")]
        public string Pseudonim { get; set; }
        [JsonProperty("UczenPlec")]
        public int UczenPlec { get; set; }
        [JsonProperty("Pozycja")]
        public int Pozycja { get; set; }
        [JsonProperty("LoginId")]
        public object LoginId { get; set; }
    }
}
