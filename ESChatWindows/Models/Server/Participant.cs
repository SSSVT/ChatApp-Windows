using Newtonsoft.Json;
using System;

namespace ESChatWindows.Models.Server
{
    public class Participant
    {
        public Guid ID { get; set; }
        public long IDRoom { get; set; }
        public long IDUser { get; set; }

        #region Virtual
        [JsonIgnore]
        public virtual Room Room { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        #endregion
    }
}
