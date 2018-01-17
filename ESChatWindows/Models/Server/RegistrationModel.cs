using System;

namespace ESChatWindows.Models.Server
{
    public class RegistrationModel : UserCredentials
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
    }
}
