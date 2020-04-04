using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;
using UONETAutoRead.Models;
using UONETAutoRead.Utils;
using System.Linq;

namespace UONETAutoRead
{
    class Program
    {
        private static HttpClient httpClient = new HttpClient();
        private static RegisteredClient registeredClient;
        private static Timer timer = new Timer();
        static async Task Main(string[] args)
        { 
            if (File.Exists(UonetVariables.Paths.Credentials))
            {
                try
                {
                    MiscUtils.PrintFormatted("Wczytywanie danych uwierzytelniających");
                    registeredClient = await VulcanUtils.ReadCredentials(httpClient);

                }
                catch (InvalidCastException ex)
                {
                    MiscUtils.PrintFormatted(ex.Message);
                    return;
                }
                catch (Exception ex)
                {
                    MiscUtils.PrintFormatted("Wystapil nieznany blad! " + ex.Message);
                    return;
                }
            }
            else
            {
                MiscUtils.PrintFormatted("Brak pliku z danymi uwierzytelniającymi. Podaj dane do rejestracji urządzenia mobilnego.");
                Console.Write("Token: ");
                string x = Console.ReadLine();
                Console.Write("Symbol: ");
                string y = Console.ReadLine();
                Console.Write("PIN: ");
                int z = Convert.ToInt32(Console.ReadLine());
                VulcanRegistration client = new VulcanRegistration(x, y, z, httpClient);
                try
                {
                    registeredClient = await client.Register();
                }
                catch (System.Security.Authentication.InvalidCredentialException ex)
                {
                    MiscUtils.PrintFormatted(ex.Message);
                    return;
                }
                catch (System.Security.Authentication.AuthenticationException ex)
                {
                    MiscUtils.PrintFormatted(ex.Message);
                    return;
                }
                catch (HttpRequestException ex)
                {
                    MiscUtils.PrintFormatted(ex.Message);
                    return;
                }
            }
            MiscUtils.PrintFormatted("Rozpoczynanie");
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(ReadMessages);
            timer.Interval = UonetVariables.MessagesConfig.InitialRefreshRateInMilliseconds;
            timer.Enabled = true;
            while (Console.Read() != 'q') ;
        }
        private static async void ReadMessages(object source, ElapsedEventArgs e)
        {
            timer.Interval = UonetVariables.MessagesConfig.RefreshRateInMilliseconds;
            try
            {
                var messages = await VulcanUtils.GetWiadomosci(registeredClient, httpClient, true);
                var unread = messages.Data.Where(i => i.DataPrzeczytaniaUnixEpoch == null).ToList();
                if (unread.Count > 0)
                {
                    MiscUtils.PrintFormatted($"Oznaczanie jako przeczytane {unread.Count} wiadomośc(i).");
                    var responses = await VulcanUtils.ReadAllMessages(registeredClient, httpClient, unread);
                    for(int z = 0; z > responses.Count; z++)
                    {
                        MiscUtils.PrintFormatted($"Odczytano wiadomość od {unread[z].Nadawca}, temat - {unread[z].Tytul}");
                    }
                }
            }
            catch(Exception ex)
            {
                MiscUtils.PrintFormatted(ex.Message);
                return;
            }
        }
    }
}
