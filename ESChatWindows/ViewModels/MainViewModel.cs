using ESChatWindows.Models.Server;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatWindows.ViewModels
{
    public class MainViewModel// : INotifyPropertyChanged
    {
        public MainViewModel()
        {

        }

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        #region ObservableCollections
        public ObservableCollection<Room> Rooms { get; protected set; }
        public ObservableCollection<Friendship> Friendships { get; protected set; }
        #endregion
        #region Token

        #endregion
        #region User

        #endregion
        #endregion
    }
}
