using System.Collections.Generic;
using Newtonsoft.Json;
namespace UONETAutoRead.Models
{
    public class SlownikiResponse
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
        public SlownikiData Data { get; set; }
    }

    public class SlownikiData
    {
        [JsonProperty("TimeKey")]
        public int TimeKey { get; set; }
        [JsonProperty("Nauczyciele")]
        public List<Nauczyciele> Nauczyciele { get; set; }
        [JsonProperty("Pracownicy")]
        public List<Pracownicy> Pracownicy { get; set; }
        [JsonProperty("Przedmioty")]
        public List<Przedmioty> Przedmioty { get; set; }
        [JsonProperty("PoryLekcji")]
        public List<PoryLekcji> PoryLekcji { get; set; }
        [JsonProperty("KategoriaOcen")]
        public List<KategorieOcen> KategorieOcen { get; set; }
        [JsonProperty("KategorieUwag")]
        public List<KategorieUwag> KategorieUwag { get; set; }
        [JsonProperty("KategorieFrekwencji")]
        public List<KategorieFrekwencji> KategorieFrekwencji { get; set; }
        [JsonProperty("TypyFrekwencji")]
        public List<TypyFrekwencji> TypyFrekwencji { get; set; }
    }

    public class Nauczyciele
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Imie")]
        public string Imie { get; set; }
        [JsonProperty("Nazwisko")]
        public string Nazwisko { get; set; }
        [JsonProperty("Kod")]
        public string Kod { get; set; }
        [JsonProperty("Aktywny")]
        public bool Aktywny { get; set; }
        [JsonProperty("Nauczyciel")]
        public bool Nauczyciel { get; set; }
        [JsonProperty("LoginId")]
        public int LoginId { get; set; }
    }

    public class Pracownicy
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Imie")]
        public string Imie { get; set; }
        [JsonProperty("Nazwisko")]
        public string Nazwisko { get; set; }
        [JsonProperty("Kod")]
        public string Kod { get; set; }
        [JsonProperty("Aktywny")]
        public bool Aktywny { get; set; }
        [JsonProperty("Nauczyciel")]
        public bool Nauczyciel { get; set; }
        [JsonProperty("LoginId")]
        public int LoginId { get; set; }
    }

    public class Przedmioty
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Nazwa")]
        public string Nazwa { get; set; }
        [JsonProperty("Kod")]
        public string Kod { get; set; }
        [JsonProperty("Aktywny")]
        public bool Aktywny { get; set; }
        [JsonProperty("Pozycja")]
        public int Pozycja { get; set; }
    }

    public class PoryLekcji
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Numer")]
        public int Numer { get; set; }
        [JsonProperty("Poczatek")]
        public int Poczatek { get; set; }
        [JsonProperty("PoczatekTekst")]
        public string PoczatekTekst { get; set; }
        [JsonProperty("Koniec")]
        public int Koniec { get; set; }
        [JsonProperty("KoniecTekst")]
        public string KoniecTekst { get; set; }
    }

    public class KategorieOcen
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Kod")]
        public string Kod { get; set; }
        [JsonProperty("Nazwa")]
        public string Nazwa { get; set; }
    }

    public class KategorieUwag
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Nazwa")]
        public string Nazwa { get; set; }
        [JsonProperty("Aktywny")]
        public bool Aktywny { get; set; }
    }

    public class KategorieFrekwencji
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Nazwa")]
        public string Nazwa { get; set; }
        [JsonProperty("Pozycja")]
        public int Pozycja { get; set; }
        [JsonProperty("Obecnosc")]
        public bool Obecnosc { get; set; }
        [JsonProperty("Nieobecnosc")]
        public bool Nieobecnosc { get; set; }
        [JsonProperty("Zwolnienie")]
        public bool Zwolnienie { get; set; }
        [JsonProperty("Spoznienie")]
        public bool Spoznienie { get; set; }
        [JsonProperty("Usprawiedliwione")]
        public bool Usprawiedliwione { get; set; }
        [JsonProperty("Usuniete")]
        public bool Usuniete { get; set; }
    }

    public class TypyFrekwencji
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Symbol")]
        public string Symbol { get; set; }
        [JsonProperty("Nazwa")]
        public string Nazwa { get; set; }
        [JsonProperty("Aktywny")]
        public bool Aktywny { get; set; }
        [JsonProperty("WpisDomyslny")]
        public bool WpisDomyslny { get; set; }
        [JsonProperty("IdKategoriaFrek")]
        public int IdKategoriaFrek { get; set; }
    }

}
