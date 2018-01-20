using Newtonsoft.Json;
using System;

namespace ESChatWindows.Models.Server
{
    public class TokenModel
    {
        public string Token { get; set; }
        public string Exp { get; set; }
        public string Type { get; set; }

        [JsonIgnore]
        public DateTime Expiration
        {
            get
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Convert.ToInt64(this.Exp)).ToUniversalTime();
            }
        }
    }
}
