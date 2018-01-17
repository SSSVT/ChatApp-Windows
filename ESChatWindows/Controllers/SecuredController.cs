using ESChatWindows.Data;
using ESChatWindows.Models.Server;
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
            TokenModel token = ApplicationDataContext.GetInstance().Token;

            this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.Type, token.Token);
        }
    }
}
