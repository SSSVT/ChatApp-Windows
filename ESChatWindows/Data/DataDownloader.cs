using ESChatWindows.Controllers;
using ESChatWindows.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatWindows.Data
{
    public class DataDownloader
    {
        #region Controllers
        protected UsersController UsersController { get; set; } = new UsersController(Properties.Resources.ServerUrl, "Users");
        protected RoomsController RoomsController { get; set; } = new RoomsController(Properties.Resources.ServerUrl, "Rooms");
        protected FriendshipsController FriendshipsController { get; set; } = new FriendshipsController(Properties.Resources.ServerUrl, "Friendships");
        protected MessagesController MessagesController { get; set; } = new MessagesController(Properties.Resources.ServerUrl, "Messages");
        #endregion

        public ApplicationDataContext ApplicationDataContext { get; set; } = ApplicationDataContext.GetInstance();

        public async Task GetCurrentUserAsync()
        {
            this.ApplicationDataContext.User = await this.UsersController.GetCurrentUserAsync().ConfigureAwait(false);

            IEnumerable<Room> rooms = await this.RoomsController.FindByUserIDAsync(this.ApplicationDataContext.User.ID);
            this.ApplicationDataContext.Rooms = new System.Collections.Concurrent.ConcurrentBag<Room>(rooms);
        }
    }
}
