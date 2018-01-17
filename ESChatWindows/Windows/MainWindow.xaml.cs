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
                this.ApplicationBindingDataContext = ApplicationBindingDataContext.GetInstance();
                this.ApplicationBindingDataContext.Token = loginWindow.TokenModel;
                this.DownloadData().Wait();
            }
            else
            {
                this.Close();
            }
        }

        public async Task DownloadData()
        {
            DataDownloader downloader = new DataDownloader();
            await downloader.GetCurrentUserAsync();
        }

        public ApplicationBindingDataContext ApplicationBindingDataContext { get; set; }
    }
}
