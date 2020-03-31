using Newtonsoft.Json;

namespace UONETAutoRead.Models
{
    public class PfxResponse
    {
        [JsonProperty("IsError")]
        public bool IsError { get; set; }
        [JsonProperty("IsMessageForUser")]
        public bool IsMessageForUser { get; set; }
        [JsonProperty("Message")]
        public string Message { get; set; }
        [JsonProperty("TokenKey")]
        public string TokenKey { get; set; }
        [JsonProperty("TokenStatus")]
        public string TokenStatus { get; set; }
        [JsonProperty("TokenCert")]
        public TokenCert TokenCert{ get; set; }
    }
    public class TokenCert
    {
        [JsonProperty("CertyfikatKlucz")]
        public string CertfikatKlucz { get; set; }
        [JsonProperty("CertyfikatKluczSformatowanyTekst")]
        public string CertfikatKluczSformatowanyTekst { get; set; }
        [JsonProperty("CertyfikatDataUtworzenia")]
        public long CertfikatDataUtworzenia { get; set; }
        [JsonProperty("CertyfikatDataUtworzeniaSformatowanyTekst")]
        public string CertfikatDataUtworzeniaSformatowanyTekst { get; set; }
        [JsonProperty("CertyfikatPfx")]
        public string CertyfikatPfx { get; set; }
        [JsonProperty("GrupaKlientow")]
        public string GrupaKlientow { get; set; }
        [JsonProperty("AdresBazowyRestApi")]
        public string AdresBazowyRestApi { get; set; }
        [JsonProperty("UzytkownikLogin")]
        public string UzytkownikLogin { get; set; }
        [JsonProperty("UzytkownikNazwa")]
        public string UzytkownikNazwa { get; set; }
    }
}
