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
                    Console.WriteLine("Wczytywanie danych uwierzytelniających");
                    registeredClient = await VulcanUtils.ReadCredentials(httpClient);

                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Wystapil nieznany blad! " + ex.Message);
                    return;
                }
            }
            else
            {
                Console.WriteLine("Brak pliku z danymi uwierzytelniającymi. Podaj dane do rejestracji urządzenia mobilnego.");
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
                    Console.WriteLine(ex);
                    return;
                }
                catch (System.Security.Authentication.AuthenticationException ex)
                {
                    Console.WriteLine(ex);
                    return;
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine(ex);
                    return;
                }
            }
            Console.WriteLine("Rozpoczynanie");
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
                    Console.WriteLine($"Znaleziono {unread.Count} nieodczytanych wiadomości. Oznaczanie jako przeczytane.");
                    await VulcanUtils.ReadAllMessages(registeredClient, httpClient, unread);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
