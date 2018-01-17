using ESChatWindows.Models.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ESChatWindows.Controllers
{
    public class MessagesController : SecuredController
    {
        public MessagesController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        public async Task<List<Message>> GetByUserIDAsync(long id)
        {
            try
            {
                this.SetAuthorizationHeader();

                HttpResponseMessage response = await this.HttpClient.GetAsync($"GetByUserIDAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Message>>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Message>> GetByRoomIDAsync(long id)
        {
            try
            {
                this.SetAuthorizationHeader();

                HttpResponseMessage response = await this.HttpClient.GetAsync($"GetByRoomIDAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Message>>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateAsync(Message message)
        {
            try
            {
                this.SetAuthorizationHeader();

                StringContent content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await this.HttpClient.PostAsync($"CreateAsync", content);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
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
