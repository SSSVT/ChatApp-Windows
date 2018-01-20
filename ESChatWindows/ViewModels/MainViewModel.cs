using ESChatWindows.Controllers;
using ESChatWindows.Models.Server;
using ESChatWindows.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ESChatWindows.ViewModels
{
    public partial class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Task cut = Task.Run(async () => {
                UsersController usersController = new UsersController(Properties.Resources.ServerUrl, "Users");
                this.CurrentUser = await usersController.GetCurrentUserAsync();
            });
            cut.Wait();
            this.RoomsChangedCommand = new Command<Room>(this.RoomChanged);
            this.RoomAddedCommand = new Command<object>(this.RoomAdded);
            this.MessageSendCommand = new Command<string>(this.MessageSend);

            Task dwt = Task.Run(async () => {
                await this.InitialDownload();
            });
            dwt.Wait();
        }

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region ICommand
        public ICommand RoomsChangedCommand { get; protected set; }
        public ICommand RoomAddedCommand { get; protected set; }
        public ICommand MessageSendCommand { get; protected set; }
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
        #region Commands
        protected void RoomChanged(Room room)
        {
            this.SelectedRoom = room;
            this.PropertyChanged(this, new PropertyChangedEventArgs("SelectedRoom"));
        }

        protected void RoomAdded(object obj)
        {
            throw new System.NotImplementedException();
        }

        protected void MessageSend(string item)
        {
            if (this.SelectedRoom != null)
            {
                try
                {
                    Message message = new Message()
                    {
                        IDRoom = this.SelectedRoom.ID,
                        IDUser = this.CurrentUser.ID,
                        UTCSend = DateTime.UtcNow,
                        Content = item
                    };
                    Task.Run(async () => {
                        await this.MessagesController.CreateAsync(message);
                    });
                    //TODO: Download messages
                    this.SelectedRoom.Messages.Add(message);
                    throw new NotImplementedException();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Properties.Resources.WindowTitle);
                }
            }
            else
            {
                MessageBox.Show("Room is not selected", Properties.Resources.WindowTitle);
            }
        }
        #endregion

        #region Methods
        public async Task InitialDownload()
        {
            this.Rooms = new ObservableCollection<Room>(await this.RoomsController.FindByUserIDAsync(this.CurrentUser.ID));
            //TODO: Download rooms messages
            this.Friendships = new ObservableCollection<Friendship>(await this.FriendshipsController.GetByUserIDAsync(this.CurrentUser.ID));
        }
        #endregion
    }
}
