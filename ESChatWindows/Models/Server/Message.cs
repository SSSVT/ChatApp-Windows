using Newtonsoft.Json;
using System;

namespace ESChatWindows.Models.Server
{
    public class Message
    {
        public Message()
        {

        }

        public Guid ID { get; set; }
        public long IDRoom { get; set; }
        public long IDUser { get; set; }
        public DateTime? UTCSend { get; set; }
        public DateTime? UTCServerReceived { get; set; }
        public string Content { get; set; }

        #region Virtual
        [JsonIgnore]
        public virtual User Owner { get; set; }
        #endregion
    }
}
