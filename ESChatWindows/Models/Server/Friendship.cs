using Newtonsoft.Json;
using System;

namespace ESChatWindows.Models.Server
{
    public class Friendship
    {
        public Guid ID { get; set; }
        public long IDSender { get; set; }
        public long IDRecipient { get; set; }
        public DateTime? UTCServerReceived { get; set; }
        public DateTime? UTCAccepted { get; set; }

        #region Virtual
        [JsonIgnore]
        public virtual User Sender { get; set; }
        [JsonIgnore]
        public virtual User Recipient { get; set; }

        public void Update(Friendship item)
        {
            this.UTCAccepted = item.UTCAccepted;
        }
        #endregion
    }
}
