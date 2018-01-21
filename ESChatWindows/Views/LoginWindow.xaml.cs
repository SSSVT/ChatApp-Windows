using ESChatWindows.Controllers;
using ESChatWindows.Models.Server;
using ESChatWindows.Objects;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace ESChatWindows.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            this.TokenController = new TokenController(Properties.Resources.ServerUrl, "Token");
        }

        protected TokenController TokenController { get; set; }

        private void ButtonForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            ForgotPasswordWindow window = new ForgotPasswordWindow();
            if (window.ShowDialog() == true)
            {
                throw new NotImplementedException();
            }
        }

        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = this.wtbx_username.Text;
            string password = this.wtbx_password.Password;

            if (Regex.IsMatch(username, "[a-zA-Z0-9]{4,64}") && Regex.IsMatch(password, ".{8,128}"))
            {
                try
                {
                    UserCredentials credentials = new UserCredentials(username, password);
                    TokenModel token = await this.TokenController.LoginAsync(credentials);

                    TokenManager.SetToken(token);
                    Properties.Settings.Default.Username = credentials.Username;
                    Properties.Settings.Default.Password = credentials.Password;

                    MainWindow window = new MainWindow();
                    window.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Properties.Resources.WindowTitle);
                }
            }
            else
            {
                MessageBox.Show(this, "Invalid login", Properties.Resources.WindowTitle);
            }
        }
    }
}
