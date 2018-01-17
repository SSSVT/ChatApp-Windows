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
                return new DateTime(Convert.ToInt64(this.Exp));
            }
        }
    }
}
