using UONETAutoRead.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UONETAutoRead.Utils
{
    static class VulcanUtils
    {
        public static async Task SaveCredentials(RegisteredClient client)
        {
            await File.WriteAllTextAsync(UonetVariables.Paths.Credentials, JsonConvert.SerializeObject(client, Formatting.Indented));
        }
        public static async Task<RegisteredClient> ReadCredentials(HttpClient httpClient)
        {
            //before returning instance of a client, method starts to verify credentials by requesting studentslist and checking if data is equal to the stored one. it also checks the certificates validity.
            var client = JsonConvert.DeserializeObject<RegisteredClient>(await File.ReadAllTextAsync(UonetVariables.Paths.Credentials));
            CryptoUtils.ImportPfx(client.Certificates.CertyfikatPfx);


            RequestBody body = new RequestBody().GenerateGenericRequestBody();
            string bodyText = JsonConvert.SerializeObject(body, Formatting.Indented);
            RequestParameters parameters = new RequestParameters
            {
                httpClient = httpClient,
                url = NetUtils.BuildUri(client.RestApi, client.Symbol, UonetVariables.Urls.ListaUczniow),
                method = "POST",
                body = bodyText,
                Headers = NetUtils.GenerateGenericHeaders(client.Certificates, bodyText)
            };

            var data = JsonConvert.DeserializeObject<ListaUczniowResponse>(await NetUtils.Query(parameters));
            if (data.Status == "Ok" && data.Data.Count != 0)
            {
                if (JsonConvert.SerializeObject(data.Data[0], Formatting.Indented) != JsonConvert.SerializeObject(client.Data, Formatting.Indented))
                {
                    MiscUtils.PrintFormatted("Wystapila zmiana w danych uwierzytelniajacych");
                    client.Data = data.Data[0];
                    await SaveCredentials(client);
                }
                return client;
            }
            throw new InvalidCredentialException("Wystąpił błąd podczas wczytywania danych uwierzytelniających.");
        }
        public static async Task<SlownikiResponse> GetSlowniki(RegisteredClient client, HttpClient httpClient)
        {
            RequestBody body = new RequestBody().GenerateGenericRequestBody();
            string bodyText = JsonConvert.SerializeObject(body, Formatting.Indented);
            RequestParameters parameters = new RequestParameters
            {
                httpClient = httpClient,
                url = NetUtils.BuildUri(client.RestApi, client.Symbol, client.Data.JednostkaSprawozdawczaSymbol, UonetVariables.Urls.Slowniki),
                method = "POST",
                body = bodyText,
                Headers = NetUtils.GenerateGenericHeaders(client.Certificates, bodyText)
            };
            return JsonConvert.DeserializeObject<SlownikiResponse>(await NetUtils.Query(parameters));
        }
        public static async Task<WiadomosciOdebrane> GetWiadomosci(RegisteredClient client, HttpClient httpClient, bool InitialRequest = false)
        {
            RequestBody body = new RequestBody().GenerateGenericRequestBody();
            body.DataPoczatkowa = InitialRequest ? client.Data.OkresDataOd : DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            body.DataKoncowa = InitialRequest ? client.Data.OkresDataDo : DateTimeOffset.UtcNow.ToUnixTimeSeconds() - UonetVariables.MessagesConfig.UnixSecondsToLookBackForMessage;
            body.LoginId = client.Data.UzytkownikLoginId;
            body.IdUczen = client.Data.Id;
            string bodyText = JsonConvert.SerializeObject(body, Formatting.Indented);
            RequestParameters parameters = new RequestParameters
            {
                httpClient = httpClient,
                url = NetUtils.BuildUri(client.RestApi, client.Symbol, client.Data.JednostkaSprawozdawczaSymbol, UonetVariables.Urls.WiadomosciOdebrane),
                method = "POST",
                body = bodyText,
                Headers = NetUtils.GenerateGenericHeaders(client.Certificates, bodyText)
            };
            var response = await NetUtils.Query(parameters);
            string ResponseSanitized = "";
            foreach(char c in response)
            {
                int cint = Convert.ToInt32(c);
                if(cint != 8221 && cint != 8222)
                {
                    ResponseSanitized += c;
                }
            }
            return JsonConvert.DeserializeObject<WiadomosciOdebrane>(ResponseSanitized);
        }
        public static async Task<List<ZmienStatusWiadomosciResponse>> ReadAllMessages(RegisteredClient client, HttpClient httpClient, List<Wiadomosc> messages)
        {
            List<ZmienStatusWiadomosciResponse> responses = new List<ZmienStatusWiadomosciResponse>();
            foreach (Wiadomosc message in messages)
            {
                if (message.DataPrzeczytaniaUnixEpoch == null)
                {
                    RequestBody body = new RequestBody().GenerateGenericRequestBody();
                    body.WiadomoscId = message.WiadomoscId;
                    body.FolderWiadomosci = message.FolderWiadomosci;
                    body.Status = message.StatusWiadomosci;
                    body.LoginId = client.Data.UzytkownikLoginId;
                    body.IdUczen = client.Data.Id;
                    string bodyText = JsonConvert.SerializeObject(body, Formatting.Indented);
                    RequestParameters parameters = new RequestParameters
                    {
                        httpClient = httpClient,
                        url = NetUtils.BuildUri(client.RestApi, client.Symbol, client.Data.JednostkaSprawozdawczaSymbol, UonetVariables.Urls.ZmienStatusWiadomosci),
                        method = "POST",
                        body = bodyText,
                        Headers = NetUtils.GenerateGenericHeaders(client.Certificates, bodyText)
                    };
                    responses.Add(JsonConvert.DeserializeObject<ZmienStatusWiadomosciResponse>(await NetUtils.Query(parameters)));
                }
            }
            return responses;
        }
    }
}
