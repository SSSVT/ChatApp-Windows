using ESChatWindows.Controllers;
using ESChatWindows.Data;
using ESChatWindows.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ESChatWindows.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoginWindow loginWindow = new LoginWindow(Properties.Resources.ServerUrl);
            if (loginWindow.ShowDialog() == true)
            {
                this.ApplicationDataContext = ApplicationDataContext.GetInstance();
                this.ApplicationDataContext.Token = loginWindow.TokenModel;
                this.DownloadData().Wait();
            }
            else
            {
                this.Close();
            }
        }

        public async Task DownloadData()
        {
            UsersController usersController = new UsersController(Properties.Resources.ServerUrl, "Users");
            RoomsController roomsController = new RoomsController(Properties.Resources.ServerUrl, "Rooms");

            this.ApplicationDataContext.User = await usersController.GetCurrentUserAsync().ConfigureAwait(false);

            IEnumerable<Room> rooms = await roomsController.FindByUserIDAsync(this.ApplicationDataContext.User.ID);
            this.ApplicationDataContext.Rooms = new System.Collections.Concurrent.ConcurrentBag<Room>(rooms);
        }

        public ApplicationDataContext ApplicationDataContext { get; set; }
    }
}
