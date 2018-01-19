using ESChatWindows.Controllers;
using ESChatWindows.Models.Server;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;

namespace ESChatWindows.Views
{
    /// <summary>
    /// Interaction logic for UserSearchWindow.xaml
    /// </summary>
    public partial class UserSearchWindow : Window
    {
        public UserSearchWindow()
        {
            InitializeComponent();
        }

        protected UsersController UsersController { get; set; } = new UsersController(Properties.Resources.ServerUrl, "Users");

        private async void WTBUsername_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                IEnumerable<User> users = await this.UsersController.SearchForUsersByUsernameAsync((sender as WatermarkTextBox).Text);

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(this, ex.Message, Properties.Resources.WindowTitle);
            }            
        }
    }
}
