using ESChatWindows.Data;
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

            goto next;

            LoginWindow loginWindow = new LoginWindow(Properties.Resources.ServerUrl);
            if (loginWindow.ShowDialog() != true)
            {
                this.Close();
            }

            this.ApplicationDataContext = ApplicationDataContext.GetInstance();
            this.ApplicationDataContext.Token = loginWindow.TokenModel;

            next:;
        }

        public ApplicationDataContext ApplicationDataContext { get; set; }
    }
}
