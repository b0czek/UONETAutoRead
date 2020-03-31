using System;

namespace UONETAutoRead.Models
{
    static class UonetVariables
    {
        public static class Urls
        {
            public static Uri RoutingRules = new Uri("http://komponenty.vulcan.net.pl/UonetPlusMobile/RoutingRules.txt");
            public static string Certyfikat = "mobile-api/Uczen.v3.UczenStart/Certyfikat";
            public static string ListaUczniow = "mobile-api/Uczen.v3.UczenStart/ListaUczniow";
            public static string LogAppStart = "mobile-api/Uczen.v3.Uczen/LogAppStart";
            public static string PlanLekcji = "mobile-api/Uczen.v3.Uczen/PlanLekcjiZeZmianami";
            public static string Slowniki = "mobile-api/Uczen.v3.Uczen/Slowniki";
            public static string WiadomosciOdebrane = "mobile-api/Uczen.v3.Uczen/WiadomosciOdebrane";
            public static string ZmienStatusWiadomosci = "/mobile-api/Uczen.v3.Uczen/ZmienStatusWiadomosci";
        }
        public static class AppInfo
        {
            public static string DeviceID = Guid.NewGuid().ToString();
            public static string Device = "Plan lekcji widżet";
            public static string AppVersion = "20.2.1.456";
            public static string AppName = "VULCAN-Android-ModulUcznia";
            public static string DeviceNameUser = "";
            public static string DeviceDescription = "";
            public static string DeviceSystemType = "Android";
            public static string DeviceSystemVersion = "6.0.1";
        }
        public static class Paths
        {
            public static string Credentials = "credentials.json";
        }
        public static class FormVariables
        {
            public static int RowOffset = 2;
            public static int ColumnOffset = 1;
            public static int TimeTableColumn = 0;
            public static int WeekDaysRow = 1;
        }
        public static class MessagesConfig
        {
            public static long UnixSecondsToLookBackForMessage = 3600;
            public static int RefreshRateInSeconds = 20;
            public static int RefreshRateInMilliseconds { 
                get
                {
                    return RefreshRateInSeconds * 1000;
                }
                set
                {
                    RefreshRateInSeconds = value / 1000;
                }
            }            
            public static int InitialRefreshRateInSeconds = 20;
            public static int InitialRefreshRateInMilliseconds { 
                get
                {
                    return InitialRefreshRateInSeconds * 1000;
                }
                set
                {
                    InitialRefreshRateInSeconds = value / 1000;
                }
            }

        }
    }
}
