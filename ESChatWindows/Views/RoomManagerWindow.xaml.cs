using ESChatWindows.Models.Server;
using System.Windows;

namespace ESChatWindows.Views
{
    public partial class RoomManagerWindow : Window
    {
        public RoomManagerWindow()
        {
            InitializeComponent();
            this.Room = new Room();
        }
        public RoomManagerWindow(Room room) : this()
        {
            this.Room = room;
            this.WTBName.Text = room.Name;
            this.WTBDescription.Text = room.Description;
        }

        public Room Room { get; protected set; }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            this.Room.Name = this.WTBName.Text;
            this.Room.Description = this.WTBDescription.Text;
            this.DialogResult = true;
        }
    }
}
