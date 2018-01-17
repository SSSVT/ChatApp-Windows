using ESChatWindows.Models.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ESChatWindows.Controllers
{
    public class ParticipantsController : SecuredController
    {
        public ParticipantsController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        public async Task<List<Participant>> GetByUserIDAsync(long id)
        {
            try
            {
                this.SetAuthorizationHeader();

                HttpResponseMessage response = await this.HttpClient.GetAsync($"GetByUserIDAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Participant>>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Participant>> GetByRoomIDAsync(long id)
        {
            try
            {
                this.SetAuthorizationHeader();

                HttpResponseMessage response = await this.HttpClient.GetAsync($"GetByRoomIDAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Participant>>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Participant> PostParticipantAsync(Participant participant)
        {
            try
            {
                this.SetAuthorizationHeader();

                StringContent content = new StringContent(JsonConvert.SerializeObject(participant), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await this.HttpClient.PostAsync($"PostParticipantAsync", content);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Participant>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Participant> DeleteParticipantAsync(Guid id)
        {
            try
            {
                this.SetAuthorizationHeader();

                HttpResponseMessage response = await this.HttpClient.DeleteAsync($"DeleteParticipantAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Participant>(responseContent);
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
