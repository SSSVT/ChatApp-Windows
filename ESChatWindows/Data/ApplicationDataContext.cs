using ESChatWindows.Models.Server;
using System.Collections.Concurrent;
using System.Linq;

namespace ESChatWindows.Data
{
    public class ApplicationDataContext
    {
        #region Singleton
        protected ApplicationDataContext()
        {
            this.Friendships = new ConcurrentBag<Friendship>();
            this.Messages = new ConcurrentBag<Message>();
            this.Participant = new ConcurrentBag<Participant>();
            //TODO: Remove tmp items
            this.Rooms = new ConcurrentBag<Room>(new Room[]
            {
                new Room("Room 1", "Description 1"),
                new Room("Room 2", "Description 2"),
                new Room("Room 3", "Description 3"),
                new Room("Room 4", "Description 4"),
            });
            this.Users = new ConcurrentBag<User>();
        }
        public static ApplicationDataContext _Instance { get; set; }
        public static ApplicationDataContext GetInstance()
        {
            if (ApplicationDataContext._Instance == null)
                ApplicationDataContext._Instance = new ApplicationDataContext();
            return ApplicationDataContext._Instance;
        }
        #endregion

        public ConcurrentBag<Friendship> Friendships { get; set; }
        public ConcurrentBag<Message> Messages { get; set; }
        public ConcurrentBag<Participant> Participant { get; set; }
        public ConcurrentBag<Room> Rooms { get; set; }
        public ConcurrentBag<User> Users { get; set; }

        #region CurrentUser
        protected object CurrentUserLock = new object();
        protected User _User;
        public User User
        {
            get
            {
                lock (CurrentUserLock)
                {
                    return _User;
                }
            }
            set
            {
                lock (CurrentUserLock)
                {
                    _User = value;
                }
            }
        }
        #endregion

        #region Token
        protected object TokenLock = new object();
        protected TokenModel _Token;
        public TokenModel Token
        {
            get
            {
                lock (TokenLock)
                {
                    return _Token;
                }
            }
            set
            {
                lock (TokenLock)
                {
                    _Token = value;
                }
            }
        }
        #endregion
    }
}
