using Newtonsoft.Json;
using System;

namespace UONETAutoRead.Models
{
    class RegisteredClient
    {
        [JsonProperty("Data")]
        public ListaUczniowData Data;
        [JsonProperty("Certificates")]
        public Certificates Certificates;
        [JsonProperty("RestApi")]
        public Uri RestApi;
        [JsonProperty("Symbol")]
        public string Symbol;
    }
}
