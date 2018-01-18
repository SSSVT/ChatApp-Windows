using ESChatWindows.Controllers;
using ESChatWindows.Models.Server;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace ESChatWindows.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow(string serverUrl)
        {
            InitializeComponent();
            this.TokenController = new TokenController(serverUrl, "Token");
        }

        public TokenModel TokenModel { get; protected set; }
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
                UserCredentials credentials = new UserCredentials(username, password);
                this.TokenModel = await this.TokenController.LoginAsync(credentials);

                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show(this, "Invalid login", Properties.Resources.WindowTitle);
            }
        }
    }
}
