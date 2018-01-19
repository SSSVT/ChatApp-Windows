using System.Net.Http.Headers;

namespace ESChatWindows.Controllers
{
    public abstract class SecuredController : Controller
    {
        public SecuredController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        protected void SetAuthorizationHeader()
        {
            this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Properties.Settings.Default.TokenType, Properties.Settings.Default.TokenValue);
        }
    }
}
