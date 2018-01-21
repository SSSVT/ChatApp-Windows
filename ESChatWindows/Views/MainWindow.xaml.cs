using ESChatWindows.ViewModels;
using System.Windows;

namespace ESChatWindows.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainViewModel mainViewModel = this.DataContext as MainViewModel;
            mainViewModel.PropertyChanged += MainWindow_PropertyChanged;
            mainViewModel.OnMessageSend += MainViewModel_OnMessageSend;
        }

        private void MainViewModel_OnMessageSend()
        {
            this.wtbx_MessageBox.Text = "";
            this.ListBoxMessages_ScrollDown();
        }

        private void MainWindow_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedRoom")
            {
                this.ListBoxMessages_ScrollDown();
            }
        }

        public void ListBoxMessages_ScrollDown()
        {
            this.ListBoxMessages.SelectedIndex = this.ListBoxMessages.Items.Count - 1;
            this.ListBoxMessages.ScrollIntoView(this.ListBoxMessages.SelectedItem);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            this.Close();
        }
    }
}
