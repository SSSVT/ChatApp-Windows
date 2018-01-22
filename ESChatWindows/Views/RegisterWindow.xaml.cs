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

namespace ESChatWindows.Views
{
    /// <summary>
    /// Interakční logika pro RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationModel RegModel = new RegistrationModel();

            RegModel.FirstName = this.wtbx_first_name.Text;
            RegModel.MiddleName = this.wtbx_middle_name.Text;
            RegModel.LastName = this.wtbx_last_name.Text;
            RegModel.Gender = this.rdBtn_male.IsChecked.ToString();
            RegModel.Gender = this.rdBtn_female.IsChecked.ToString();
            RegModel.Email = this.wtbx_email.Text;
            RegModel.Username = this.wtbx_username.Text;
            RegModel.Password = this.wtbx_password.Text;
            RegModel.Birthdate = this.dtp_birthdate.SelectedDate;
        }
    }
}
