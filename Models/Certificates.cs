namespace UONETAutoRead.Models
{
    class Certificates
    {
        public string CertyfikatKlucz { get; set; }
        public string CertyfikatPfx { get; set; }

        public Certificates(string CertKlucz, string CertPfx)
        {
            CertyfikatKlucz = CertKlucz;
            CertyfikatPfx = CertPfx;
        }
    }
}
