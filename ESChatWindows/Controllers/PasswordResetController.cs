using ESChatWindows.Models.Server;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ESChatWindows.Controllers
{
    public class PasswordResetController : SecuredController
    {
        public PasswordResetController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        public async Task ForgotPasswordAsync(string username)
        {
            try
            {
                HttpResponseMessage response = await this.HttpClient.GetAsync($"ForgotPasswordAsync/{username}");

                if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
                {
                    throw new HttpRequestException($"There was an exception: { response.StatusCode }");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ResetPasswordAsync(PasswordResetModel passwordReset)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(passwordReset), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await this.HttpClient.PostAsync($"ResetPasswordAsync/{passwordReset.ID}", content);

                if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
                {
                    throw new HttpRequestException($"There was an exception: { response.StatusCode }");
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
