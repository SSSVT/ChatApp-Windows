using ESChatWindows.Models.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ESChatWindows.Controllers
{
    public class UsersController : SecuredController
    {
        public UsersController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        public async Task<User> GetCurrentUserAsync()
        {
            try
            {
                this.SetAuthorizationHeader();

                HttpResponseMessage response = await this.HttpClient.GetAsync($"GetCurrentUserAsync").ConfigureAwait(false);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
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

        public async Task<List<User>> SearchForUsersByUsernameAsync(string id)
        {
            try
            {
                this.SetAuthorizationHeader();

                HttpResponseMessage response = await this.HttpClient.GetAsync($"SearchForUsersByUsernameAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<User>>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> FindByUsernameAsync(string id)
        {
            try
            {
                this.SetAuthorizationHeader();

                HttpResponseMessage response = await this.HttpClient.GetAsync($"FindByUsernameAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
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

        public async Task<User> DetailAsync(long id)
        {
            try
            {
                this.SetAuthorizationHeader();

                HttpResponseMessage response = await this.HttpClient.GetAsync($"DetailAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
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

        public async Task UpdateAsync(User user)
        {
            try
            {
                this.SetAuthorizationHeader();

                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await this.HttpClient.PutAsync($"UpdateAsync/{user.ID}", content);

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return;
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
