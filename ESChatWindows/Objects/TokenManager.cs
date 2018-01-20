using ESChatWindows.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatWindows.Objects
{
    public static class TokenManager
    {
        public static void SetToken(TokenModel token)
        {
            Properties.Settings.Default.TokenValue = token.Token;
            Properties.Settings.Default.TokenType = token.Type;
            Properties.Settings.Default.TokenExp = token.Expiration.ToString();
        }
    }
}
