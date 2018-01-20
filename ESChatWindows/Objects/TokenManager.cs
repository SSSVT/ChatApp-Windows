using ESChatWindows.Models.Server;

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
