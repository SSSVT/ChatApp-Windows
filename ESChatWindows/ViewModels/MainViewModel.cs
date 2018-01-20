using ESChatWindows.Controllers;
using ESChatWindows.Models.Server;
using ESChatWindows.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace ESChatWindows.ViewModels
{
    public partial class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Task.Run(async () => {
                UsersController usersController = new UsersController(Properties.Resources.ServerUrl, "Users");
                this.CurrentUser = await usersController.GetCurrentUserAsync();
            }).Wait();
            this.StartPeriodicWorker();
            this.RoomsChangedCommand = new Command<Room>(this.RoomChanged);
            this.RoomAddedCommand = new Command<object>(this.RoomAdded);
            this.MessageSendCommand = new Command<string>(this.MessageSend);

            Task.Run(async () => {
                await this.DownloadDataFromServer();
            }).Wait();
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

        protected readonly BackgroundWorker _backgroundWorker = new BackgroundWorker();
        protected readonly Timer _timer = new Timer(2000);
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
        public async Task DownloadDataFromServer()
        {
            this.Rooms = new ObservableCollection<Room>(await this.RoomsController.FindByUserIDAsync(this.CurrentUser.ID));

            foreach (Room room in this.Rooms)
            {
                room.Messages = new ObservableCollection<Message>(await this.MessagesController.GetByRoomIDAsync(room.ID));
            }

            this.Friendships = new ObservableCollection<Friendship>(await this.FriendshipsController.GetByUserIDAsync(this.CurrentUser.ID));
        }
        public void StartPeriodicWorker()
        {
            this._timer.Elapsed += _timer_Elapsed;
            this._timer.Interval = 20000;
            //this._timer.Start();

            this._backgroundWorker.DoWork += _backgroundWorker_DoWork;
            this._backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            //this._backgroundWorker.RunWorkerAsync();
        }

        protected void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this._backgroundWorker.RunWorkerAsync();
        }

        protected void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this._backgroundWorker.RunWorkerAsync();
        }

        protected void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Task.Run(async () =>
            {
                await this.DownloadDataFromServer();
            }).Wait();
        }
        #endregion
    }
}
