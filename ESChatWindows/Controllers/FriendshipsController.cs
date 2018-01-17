using ESChatWindows.Models.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ESChatWindows.Controllers
{
    public class FriendshipsController : SecuredController
    {
        public FriendshipsController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        public async Task<List<Friendship>> GetByUserIDAsync(long id)
        {
            try
            {
                this.SetAuthorizationHeader();

                HttpResponseMessage response = await this.HttpClient.GetAsync($"GetByUserIDAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Friendship>>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Friendship>> GetAcceptedByUserIDAsync(long id)
        {
            try
            {
                this.SetAuthorizationHeader();

                HttpResponseMessage response = await this.HttpClient.GetAsync($"GetAcceptedByUserIDAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Friendship>>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Friendship>> GetReceivedAndPendingByUserIDAsync(long id)
        {
            try
            {
                this.SetAuthorizationHeader();

                HttpResponseMessage response = await this.HttpClient.GetAsync($"GetReceivedAndPendingByUserIDAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Friendship>>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Friendship> GetFriendshipAsync(Guid id)
        {
            try
            {
                this.SetAuthorizationHeader();

                HttpResponseMessage response = await this.HttpClient.GetAsync($"GetFriendshipAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Friendship>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Friendship> PostFriendshipAsync(Friendship friendship)
        {
            try
            {
                this.SetAuthorizationHeader();

                StringContent content = new StringContent(JsonConvert.SerializeObject(friendship), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await this.HttpClient.PostAsync($"PostFriendshipAsync", content);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Friendship>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Friendship> PutFriendshipAsync(Friendship friendship)
        {
            try
            {
                this.SetAuthorizationHeader();

                StringContent content = new StringContent(JsonConvert.SerializeObject(friendship), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await this.HttpClient.PutAsync($"PutFriendshipAsync/{friendship.ID}", content);

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Friendship>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Friendship> DeleteFriendshipAsync(Guid id)
        {
            try
            {
                this.SetAuthorizationHeader();

                HttpResponseMessage response = await this.HttpClient.DeleteAsync($"DeleteFriendshipAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Friendship>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Friendship> AcceptFriendshipAsync(Guid id)
        {
            try
            {
                this.SetAuthorizationHeader();

                HttpResponseMessage response = await this.HttpClient.PutAsync($"AcceptFriendshipAsync/{id}", new StringContent("", Encoding.UTF8, "application/json"));

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Friendship>(responseContent);
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
