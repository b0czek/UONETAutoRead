using System;
using System.Collections.Generic;
using System.Net.Http;

namespace UONETAutoRead.Models
{
    class RequestParameters
    {
        public HttpClient httpClient;
        public Uri url;
        public string method;
        public string body;
        public Dictionary<string, string> Headers;
        public bool MobileUserAgent = true;
    }
}
