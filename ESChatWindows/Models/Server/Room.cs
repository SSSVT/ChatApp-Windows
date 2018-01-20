using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace ESChatWindows.Models.Server
{
    public class Room
    {
        public Room()
        {
        }
        public Room(string name, string description) : this()
        {
            this.Name = name;
            this.Description = description;
        }

        public long ID { get; set; }
        public long IDOwner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? UTCCreationDate { get; set; }

        #region Virtual
        [JsonIgnore]
        public virtual User Owner { get; set; }
        [JsonIgnore]
        public virtual ObservableCollection<Participant> Participants { get; set; }
        [JsonIgnore]
        public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();
        #endregion

        public override string ToString()
        {
            return this.Name;
        }
    }
}
