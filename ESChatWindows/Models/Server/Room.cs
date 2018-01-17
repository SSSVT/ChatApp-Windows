using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ESChatWindows.Models.Server
{
    public class Room
    {
        public Room()
        {

        }
        public Room(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
        public Room(string name, string description, User owner) : this(name, description)
        {
            this.IDOwner = owner.ID;
            this.Owner = owner;
        }

        public long ID { get; set; }
        public long IDOwner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? UTCCreationDate { get; set; }

        [JsonIgnore]
        public bool IsActive { get; set; }

        #region Virtual
        [JsonIgnore]
        public virtual User Owner { get; set; }
        [JsonIgnore]
        public virtual ICollection<Participant> Participants { get; set; }
        [JsonIgnore]
        public virtual ICollection<Message> Messages { get; set; }
        #endregion
    }
}
