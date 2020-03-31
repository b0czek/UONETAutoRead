using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UONETAutoRead.Models
{

    public class WiadomosciOdebrane
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
        public List<Wiadomosc> Data { get; set; }
    }

    public class Wiadomosc
    {
        [JsonProperty("WiadomoscId")]
        public int WiadomoscId { get; set; }
        [JsonProperty("Nadawca")]
        public string Nadawca { get; set; }
        [JsonProperty("NadawcaId")]
        public int NadawcaId { get; set; }
        [JsonProperty("Adresaci")]
        public List<Adresaci> Adresaci { get; set; }
        [JsonProperty("Tytul")]
        public string Tytul { get; set; }
        [JsonProperty("Tresc")]
        public string Tresc { get; set; }
        [JsonProperty("DataWyslania")]
        public string DataWyslania { get; set; }
        [JsonProperty("DataWyslaniaUnixEpoch")]
        public int DataWyslaniaUnixEpoch { get; set; }
        [JsonProperty("GodzinaWyslania")]
        public string GodzinaWyslania { get; set; }
        [JsonProperty("DataPrzeczytania")]
        public string DataPrzeczytania { get; set; }
        [JsonProperty("DataPrzeczytaniaUnixEpoch")]
        public long? DataPrzeczytaniaUnixEpoch { get; set; }
        [JsonProperty("GodzinaPrzeczytania")]
        public string GodzinaPrzeczytania { get; set; }
        [JsonProperty("StatusWiadomosci")]
        public string StatusWiadomosci { get; set; }
        [JsonProperty("FolderWiadomosci")]
        public string FolderWiadomosci { get; set; }
        [JsonProperty("Nieprzeczytane")]
        public object Nieprzeczytane { get; set; }
        [JsonProperty("Przeczytane")]
        public object Przeczytane { get; set; }
    }
    public class Adresaci
    {
        [JsonProperty("LoginId")]
        public int LoginId { get; set; }
        [JsonProperty("Nazwa")]
        public string Nazwa { get; set; }
    }
}
