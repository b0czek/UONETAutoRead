using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UONETAutoRead.Models;
using UONETAutoRead.Utils;
using System;

namespace UONETAutoRead
{
    class VulcanRegistration
    {
        private int PIN;
        private string Symbol,Token;
        Uri RestApiURL;
        private HttpClient httpClient;

        public string OngoingAction;

        public VulcanRegistration(string token, string symbol, int pin, HttpClient client)
        {
            PIN = pin;
            Symbol = symbol;
            Token = token;
            httpClient = client;
        }

        /// <summary>
        /// Method combining other methods and going through procedure of registrating new device with UONET Api. In the end, it creates JSON file with credentials.
        /// </summary>
        /// <returns>RegisteredClient - type in where you've got student's data and their certificates</returns>
        /// <exception cref="System.Security.Authentication.InvalidCredentialException">Throws when API responds with data indicating that there's apparent problem with credentials</exception>
        /// <exception cref="System.Security.Authentication.AuthenticationException">Throws in authentication process when API responds with unpredicted stuff</exception>
        /// <exception cref="HttpRequestException">Throws on problem with sending data to API or it rejected it</exception>
        public async Task<RegisteredClient> Register()
        {
            RestApiURL = await GetRestAPI();
            var PFXResponse = await GetPFXCert();
            if (PFXResponse.IsError)
            {
                throw new System.Security.Authentication.InvalidCredentialException($"Wprowadzone dane logowania są nieprawidłowe - {PFXResponse.Message}");
            }
            else if (PFXResponse.TokenStatus != "CertGenerated")
            {
                throw new Exception($"Skrajnie nieprawdopodobny wyjątek {JsonConvert.SerializeObject(PFXResponse)}");
            }
            Certificates certificates = new Certificates(PFXResponse.TokenCert.CertfikatKlucz, PFXResponse.TokenCert.CertyfikatPfx);
            CryptoUtils.ImportPfx(certificates.CertyfikatPfx);
            var StudentsList = await GetStudentsList(certificates);
            if (StudentsList.Status != "Ok" || StudentsList.Data.Count == 0)
            {
                throw new System.Security.Authentication.AuthenticationException("Nie udało się prawidłowo pobrać informacji o uczniu!");
            }
            var AppStart = await LogAppStart(certificates, StudentsList.Data[0].JednostkaSprawozdawczaSymbol);
            if (AppStart.Status != "Ok" || AppStart.Data != "Log")
            {
                throw new System.Security.Authentication.AuthenticationException("Nie udało się prawidłowo aktywować aplikacji");
            }
            RegisteredClient registeredClient = new RegisteredClient
            {
                Data = StudentsList.Data[0],
                Certificates = certificates,
                RestApi = RestApiURL,
                Symbol = Symbol
            };
            await VulcanUtils.SaveCredentials(registeredClient);
            return registeredClient;

        }
        public async Task<Uri> GetRestAPI()
        {
            OngoingAction = "Uzyskiwanie adresu URL RestAPI";
            RequestParameters parameters = new RequestParameters
            {
                httpClient = httpClient,
                url = NetUtils.BuildUri(UonetVariables.Urls.RoutingRules),
                method = "get"
            };

            var rules = await NetUtils.Query(parameters);
            string RestToken = Token.Substring(0, 3);
            var result = rules.Split(new[] { '\r', '\n' });
            foreach(string line in result)
            {
                if(line.StartsWith(RestToken))
                {
                    return new Uri(line.Substring(4));
                }
            }
            throw new System.Security.Authentication.InvalidCredentialException("Nieprawidłowy token, nie udało się znaleźć żadnego adresu RestAPI powiązanego z tym tokenem.");
        }
        public async Task<PfxResponse> GetPFXCert()
        {
            OngoingAction = "Uzyskiwanie certyfikatu PFX";
            RequestBody body = new RequestBody().GeneratDetailedRequestBody();
            body.PIN = PIN;
            body.TokenKey = Token;
            string bodyText = JsonConvert.SerializeObject(body, Formatting.Indented);
            RequestParameters parameters = new RequestParameters
            {
                httpClient = httpClient,
                url = NetUtils.BuildUri(RestApiURL, Symbol, UonetVariables.Urls.Certyfikat),
                method = "POST",
                body = bodyText,
                Headers = new Dictionary<string, string>
                {
                    { "RequestMobileType", "RegisterDevice"}
                }
            };
            return JsonConvert.DeserializeObject<PfxResponse>(await NetUtils.Query(parameters));
            
        }
        public async Task<ListaUczniowResponse> GetStudentsList(Certificates certificates)
        {
            OngoingAction = "Pobieranie informacji o uczniu";
            RequestBody body = new RequestBody().GenerateGenericRequestBody();
            string bodyText = JsonConvert.SerializeObject(body, Formatting.Indented);

            RequestParameters parameters = new RequestParameters
            {
                httpClient = httpClient,
                url = NetUtils.BuildUri(RestApiURL, Symbol, UonetVariables.Urls.ListaUczniow),
                method = "POST",
                body = bodyText,
                Headers = NetUtils.GenerateGenericHeaders(certificates, bodyText)
            };
            return JsonConvert.DeserializeObject<ListaUczniowResponse>(await NetUtils.Query(parameters));
        }
        public async Task<LogAppStartReponse> LogAppStart(Certificates certificates, string JednostkaSprawozdawczaSymbol)
        {
            OngoingAction = "Aktywowanie aplikacji";
            RequestBody body = new RequestBody().GenerateGenericRequestBody();
            string bodyText = JsonConvert.SerializeObject(body, Formatting.Indented);
            RequestParameters parameters = new RequestParameters
            {
                httpClient = httpClient,
                url = NetUtils.BuildUri(RestApiURL, Symbol, JednostkaSprawozdawczaSymbol, UonetVariables.Urls.LogAppStart),
                method = "POST",
                body = bodyText,
                Headers = NetUtils.GenerateGenericHeaders(certificates, bodyText)
            };
            return JsonConvert.DeserializeObject<LogAppStartReponse>(await NetUtils.Query(parameters));
        }
    }
}
