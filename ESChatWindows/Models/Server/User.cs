using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
        public virtual ICollection<Room> OwnedRooms { get; set; }
        [JsonIgnore]
        public virtual ICollection<Participant> Participants { get; set; }
        [JsonIgnore]
        public virtual ICollection<Message> Messages { get; set; }
        [JsonIgnore]
        public virtual ICollection<Friendship> SentFriendships { get; set; }
        [JsonIgnore]
        public virtual ICollection<Friendship> ReceivedFriendships { get; set; }
        #endregion

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
