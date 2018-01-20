using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ESChatWindows.Models.Server
{
    public class User : RegistrationModel
    {
        public User()
        {

        }
        public User(RegistrationModel registration)
        {
            this.FirstName = registration.FirstName;
            this.MiddleName = registration.MiddleName;
            this.LastName = registration.LastName;
            this.Birthdate = registration.Birthdate;
            this.Gender = registration.Gender;
            this.Email = registration.Email;
            this.Username = registration.Username;
        }

        public long ID { get; set; }
        public DateTime? UTCRegistrationDate { get; set; }
        /// <summary>
        /// [ADIO] - Active, Do not disturb, Invisible, Offline
        /// </summary>
        public string Status { get; set; }

        #region Virtual
        [JsonIgnore]
        public virtual ObservableCollection<Room> OwnedRooms { get; set; }
        [JsonIgnore]
        public virtual ObservableCollection<Participant> Participants { get; set; }
        [JsonIgnore]
        public virtual ObservableCollection<Message> Messages { get; set; }
        [JsonIgnore]
        public virtual ObservableCollection<Friendship> SentFriendships { get; set; }
        [JsonIgnore]
        public virtual ObservableCollection<Friendship> ReceivedFriendships { get; set; }
        #endregion

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
