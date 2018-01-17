using System;

namespace ESChatWindows.Models.Server
{
    public class PasswordResetModel
    {
        //[Required]
        public Guid ID { get; set; }

        //[Required, MinLength(8), MaxLength(128)]
        //[RegularExpression(".{8,128}")]
        public string Password { get; set; }
    }
}
