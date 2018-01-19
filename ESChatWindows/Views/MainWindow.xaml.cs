using ESChatWindows.Controllers;
using ESChatWindows.Models.Server;
using ESChatWindows.ViewModels;
using System.Threading.Tasks;
using System.Windows;

namespace ESChatWindows.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoginWindow loginWindow = new LoginWindow(Properties.Resources.ServerUrl);
            if (loginWindow.ShowDialog() == true)
            {
                Properties.Settings.Default.TokenValue = loginWindow.TokenModel.Token;
                Properties.Settings.Default.TokenType = loginWindow.TokenModel.Type;
                Properties.Settings.Default.TokenExp = loginWindow.TokenModel.Exp;

                User user = new User();
                Task task = Task.Run(async () => {
                    UsersController usersController = new UsersController(Properties.Resources.ServerUrl, "Users");
                    user = await usersController.GetCurrentUserAsync();
                });
                task.Wait();

                (this.DataContext as MainViewModel).CurrentUser = user;
            }
            else
            {
                this.Close();
            }
        }
    }
}
