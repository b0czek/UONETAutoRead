using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using UONETAutoRead.Models;
using System.Text;
using System;

namespace UONETAutoRead.Utils
{
    static class NetUtils
    {
        public static Uri BuildUri(Uri uri, params string[] paths)
        {
            string url = "";
            foreach (string path in paths)
            {
                url += "/";
                url += path;
            }
            return new Uri(uri + url);
        }
        public static HttpRequestMessage BuildMessage(string method, Uri url)
        {
            return new HttpRequestMessage(new HttpMethod(method), url);
        }
        public static void AddHeaders(ref HttpRequestMessage message, Dictionary<string, string> headers, bool MobileUserAgent=true)
        {
            if (MobileUserAgent)
                message.Headers.Add("User-Agent", "MobileUserAgent");
            foreach (KeyValuePair<string, string> key in headers)
            {
                message.Headers.Add(key.Key, key.Value);
            }
        }
        public static async Task<string> Query(RequestParameters parameters)
        {
            var message = BuildMessage(parameters.method, parameters.url);
            if (parameters.body != null)
            {
                message.Content = new StringContent(parameters.body, Encoding.UTF8, "application/json");
            }
            if (parameters.Headers != null)
                AddHeaders(ref message, parameters.Headers, parameters.MobileUserAgent);
            else if(parameters.Headers == null && parameters.MobileUserAgent)
            {
                message.Headers.Add("User-Agent", "MobileUserAgent");
            }
            try
            {
                HttpResponseMessage response = await parameters.httpClient.SendAsync(message);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch(HttpRequestException)
            {
                throw;
            }
            
        }
        public static Dictionary<string,string> GenerateGenericHeaders(Certificates certificates, string body)
        {
            return new Dictionary<string, string>
            {
                {"RequestSignatureValue", CryptoUtils.Sign(body) },
                {"RequestCertificateKey", certificates.CertyfikatKlucz }
            };
        }
    }
}
