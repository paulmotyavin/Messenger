using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Messenger
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            int number = 0;
            Regex validateIPv4Regex = new Regex("^(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            if (validateIPv4Regex.IsMatch(IpAddress.Text) && !IpAddress.Text.StartsWith(" ")) number++;
            else MessageBox.Show("IP-адрес пуст или имеет неверный формат");

            Regex validateUsername = new Regex("^[a-zA-Za-åa-ö-w-я 0-9/._]{3,20}$");
            if (validateUsername.IsMatch(Username.Text) && !Username.Text.StartsWith(" ")) number++;
            else MessageBox.Show("Имя пользователя пусто или имеет неверный формат");

            if (number == 2)
            {
                TcpClient.Name = Username.Text;
                TcpClient.IPServer = IpAddress.Text;
                TcpClient tcpClient = new TcpClient();
                tcpClient.Show();
                this.Close();
            }
        }

        private void CreateChat_Click(object sender, RoutedEventArgs e)
        {
            Regex validateUsername = new Regex("^[a-zA-Za-åa-ö-w-я 0-9/._]{3,20}$");
            if (validateUsername.IsMatch(Username.Text) && !Username.Text.StartsWith(" "))
            {
                TcpServer.Name = Username.Text;
                TcpServer tcpServer = new TcpServer();
                tcpServer.Show();
                this.Close();
            }
            else MessageBox.Show("Имя пользователя пусто или имеет неверный формат");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int count = Application.Current.Windows.OfType<TcpServer>().Count();
            int count1 = Application.Current.Windows.OfType<TcpClient>().Count();
            if (count == 1 || count1 == 1)
            {
                e.Cancel = false;
            }
            else
            {
                MainWindow main = new MainWindow();
                main.Show();
            }
        }
    }
}