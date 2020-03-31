using System;
using static UONETAutoRead.Models.UonetVariables;

namespace UONETAutoRead.Models
{
    class RequestBody
    {
        //types used in registration process
        public int PIN { get; set; }
        public string TokenKey { get; set; }
        public string AppVersion { get; set; }
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceNameUser { get; set; }
        public string DeviceDescription { get; set; }
        public string DeviceSystemType { get; set; }
        public string DeviceSystemVersion { get; set; }
        //generics used universally
        public long RemoteMobileTimeKey { get; set; }
        public long TimeKey { get; set; }
        public string RequestId { get; set; }
        public string RemoteMobileAppVersion { get; set; }
        public string RemoteMobileAppName { get; set; }
        //used in queries of schedule and maybe some other
        public long DataPoczatkowa { get; set; }
        public long DataKoncowa { get; set; }
        public int IdOddzial { get; set; }
        public int IdOkresKlasyfikacyjny { get; set; }
        public int IdUczen { get; set; }
        public int LoginId { get; set; }
        //used for messages
        public int WiadomoscId { get; set; }
        public string FolderWiadomosci { get; set; }
        public string Status { get; set; }


        public RequestBody GenerateGenericRequestBody()
        {
            return new RequestBody
            {
                RemoteMobileTimeKey = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                TimeKey = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 1,
                RequestId = Guid.NewGuid().ToString(),
                RemoteMobileAppVersion = AppInfo.AppVersion,
                RemoteMobileAppName = AppInfo.AppName
            };
        }
        public RequestBody GeneratDetailedRequestBody()
        {
            return new RequestBody
            {
                AppVersion = AppInfo.AppVersion,
                DeviceId = AppInfo.DeviceID,
                DeviceName = AppInfo.Device,
                DeviceNameUser = AppInfo.DeviceNameUser,
                DeviceDescription = AppInfo.DeviceDescription,
                DeviceSystemType = AppInfo.DeviceSystemType,
                DeviceSystemVersion = AppInfo.DeviceSystemVersion,
                RemoteMobileTimeKey = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                TimeKey = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 1,
                RequestId = Guid.NewGuid().ToString(),
                RemoteMobileAppVersion = AppInfo.AppVersion,
                RemoteMobileAppName = AppInfo.AppName
            };
        }
    }
}
