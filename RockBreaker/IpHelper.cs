using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace RockBreaker
{
    [Serializable]
    public static class IpHelper
    {
        public static string GetIpAddress()
        {
            HttpClient client = new HttpClient();
            string result = client.GetStringAsync("https://jsonip.com/").Result;
            RemoteIpDto remoteIpDto = JsonConvert.DeserializeObject<RemoteIpDto>(result);
            if (remoteIpDto == null || remoteIpDto.IP == null) return string.Empty;
            return remoteIpDto.IP;
        }

        public class RemoteIpDto
        {
            [JsonPropertyName("ip")]
            public string IP { get; set; }

            [JsonPropertyName("geo-ip")]
            public string GeoIp { get; set; }

            [JsonPropertyName("API Help")]
            public string ApiHelp { get; set; }
        }
    }
}
