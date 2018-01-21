using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;

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
        public virtual ObservableCollection<Participant> Participants { get; set; } = new ObservableCollection<Participant>();
        [JsonIgnore]
        public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();
        #endregion

        public override string ToString()
        {
            return this.Name;
        }

        public virtual void Update(Room room)
        {
            this.IDOwner = room.IDOwner;
            this.Name = room.Name;
            this.Description = room.Description;
            this.UTCCreationDate = room.UTCCreationDate;

            foreach (Message item in room.Messages)
            {
                if (this.Messages.Where(x => x.ID == item.ID).FirstOrDefault() == null)
                {
                    this.Messages.Add(item);
                }
            }
            foreach (Participant item in room.Participants)
            {
                if (this.Participants.Where(x => x.ID == item.ID).FirstOrDefault() == null)
                {
                    this.Participants.Add(item);
                }
            }
        }
    }
}
