using System;
using System.Threading.Tasks;

namespace ESChatWindows.Controllers
{
    public class PasswordResetController : SecuredController
    {
        public PasswordResetController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        public async Task ForgotPasswordAsync()
        {
            throw new NotImplementedException();
        }

        public async Task ResetPasswordAsync()
        {
            throw new NotImplementedException();
        }
    }
}
