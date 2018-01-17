using ESChatWindows.Models.Server;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ESChatWindows.Controllers
{
    public class RegistrationController : Controller
    {
        public RegistrationController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        public async Task<User> RegisterAsync(RegistrationModel registration)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(registration), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await this.HttpClient.PostAsync($"RegisterAsync", content);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<User>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> IsUsernameAvailableAsync(string username)
        {
            try
            {
                HttpResponseMessage response = await this.HttpClient.GetAsync($"IsUsernameAvailableAsync/{username}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return Convert.ToBoolean(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                //TODO: Save exception ServerConnectionException
                throw;
            }
        }
    }
}
