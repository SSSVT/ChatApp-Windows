using ESChatWindows.Controllers;
using ESChatWindows.Models.Server;
using ESChatWindows.Objects;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ESChatWindows.ViewModels
{
    public partial class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Rooms = new ObservableCollection<Room>();
            this.RoomsSwitchCommand = new Command<Room>(this.RoomChanged);
            this.RoomAddedCommand = new Command<object>(this.RoomAdded);
        }

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region ICommand
        public ICommand RoomsSwitchCommand { get; protected set; }
        public ICommand RoomAddedCommand { get; protected set; }
        public ICommand CurrentUserChanged { get; protected set; }
        #endregion

        #region Controllers
        protected UsersController UsersController { get; set; } = new UsersController(Properties.Resources.ServerUrl, "Users");
        protected RoomsController RoomsController { get; set; } = new RoomsController(Properties.Resources.ServerUrl, "Rooms");
        protected FriendshipsController FriendshipsController { get; set; } = new FriendshipsController(Properties.Resources.ServerUrl, "Friendships");
        protected MessagesController MessagesController { get; set; } = new MessagesController(Properties.Resources.ServerUrl, "Messages");
        #endregion
        #region ObservableCollections
        public ObservableCollection<Room> Rooms { get; protected set; }
        public ObservableCollection<Friendship> Friendships { get; protected set; }
        #endregion
        #region Properties
        public Room SelectedRoom { get; set; }
        public User CurrentUser { get; set; }
        #endregion
    }

    public partial class MainViewModel
    {
        protected void RoomChanged(Room room)
        {
            this.SelectedRoom = room;
            this.PropertyChanged(this, new PropertyChangedEventArgs("SelectedRoom"));
        }

        protected void RoomAdded(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
