using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace UONETAutoRead.Utils
{
    static class CryptoUtils
    {
        private static X509Certificate2Collection collection = new X509Certificate2Collection();
        private static string password = "CE75EA598C7743AD9B0B7328DED85B06";

        public static string Sign(string text)
        {
            if(collection.Count != 1)
            {
                throw new System.Security.VerificationException("Nieprawidłowa ilość certyfikowatów PFX - " + collection.Count);
            }
            X509Certificate2 certificate = collection[0];

            RSA provider = (RSA)certificate.PrivateKey;
            // Hash the data
            var hash = HashText(text);
            // Sign the hash

            return Convert.ToBase64String(provider.SignHash(hash, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1));
                
        }
        
        public static byte[] HashText(string text) 
        {
            SHA1Managed sha1Hasher = new SHA1Managed();
            byte[] data = Encoding.UTF8.GetBytes(text);
            byte[] hash = sha1Hasher.ComputeHash(data);
            return hash;
        }
        public static byte[] DecodeCrt(string crt)
        {
            Span<byte> buffer = new Span<byte>(new byte[crt.Length]);
            if (Convert.TryFromBase64String(crt, buffer, out int bytesParsed))
            {
                return Convert.FromBase64String(crt);
            }
            throw new InvalidCastException("Wystapil blad przy dekodowaniu certyfikatu");
        }
        
        public static bool Verify(string text, byte[] signature)
        {

            if (collection.Count != 1)
            {
                throw new System.Security.VerificationException("Nieprawidłowa ilość certyfikowatów PFX");
            }
            X509Certificate2 certificate = collection[0];

            RSA provider = (RSA)certificate.PrivateKey;
            // Hash the data
            var hash = HashText(text);

            // Verify the signature with the hash
            var result = provider.VerifyHash(hash, signature, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            return result;
        }
        public static void ImportPfx(string pfx)
        {
            if (pfx != null)
            {
                try
                {

                    collection.Clear();
                    collection.Import(DecodeCrt(pfx), password, X509KeyStorageFlags.Exportable);
                }
                catch
                {
                    throw;
                }
            }
        }

    }
}
