using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Messenger
{
    public partial class TcpServer : Window
    {
        private Socket socket;
        public static string Name;
        private List<Socket> clients = new List<Socket>();
        private List<string> usersList = new List<string>();
        private List<string> logs = new List<string>();
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private CancellationToken token;
        private int number = 0;
        public TcpServer()
        {
            InitializeComponent();
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipPoint);
            socket.Listen(1000);
            clients.Add(socket);

            DateTime date = DateTime.Now;
            string log = $"[{date}]\nНовый пользователь: {Name}";
            usersList.Add(Name);
            UsersList.ItemsSource = null;
            UsersList.ItemsSource = usersList;
            logs.Add(log);
            LogList.ItemsSource = logs;
            Count.Text = $"Пользователи: {usersList.Count}";

            ListenToClients();
        }

        private async Task ListenToClients()
        {
            while (!token.IsCancellationRequested)
            {
                var client = await socket.AcceptAsync();
                clients.Add(client);
                UsersList.ItemsSource = null;
                UsersList.ItemsSource = clients;
                Count.Text = $"Пользователи: {clients.Count}";
                ReceiveMessage(client);
            }
        }

        private async Task ReceiveMessage(Socket client)
        {
            while (!token.IsCancellationRequested)
            {
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);

                MessagesList.Items.Add(message);

                foreach (var item in clients)
                {
                    SendMessage(item, message);
                }
            }
        }

        private async Task SendMessage(Socket client, string message)
        {
            if (!token.IsCancellationRequested)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                await client.SendAsync(bytes, SocketFlags.None);
            }
        }

        private void ExitBt_Click(object sender, RoutedEventArgs e)
        {
            token = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();
            socket.Close();
            this.Close();
        }

        private async Task sendmsg(string msg)
        {
            if (!token.IsCancellationRequested)
            {
                DateTime now = DateTime.Now;
                foreach (var item in clients)
                {
                    SendMessage(item, msg);
                }
                MessagesList.Items.Add(msg);
            }
            
        }

        private void LogChatBt_Click(object sender, RoutedEventArgs e)
        {
            if (number % 2 == 0)
            {
                Count.Visibility = Visibility.Hidden;
                LogList.Visibility = Visibility.Visible;
                UsersList.Visibility = Visibility.Hidden;
                LogChatBt.Content = "Скрыть лог чата";
            }
            else
            {
                Count.Visibility = Visibility.Visible;
                LogList.Visibility = Visibility.Hidden;
                UsersList.Visibility = Visibility.Visible;
                LogChatBt.Content = "Показать лог чата";
            }
            number++;
        }

        private async void SendBt_Click(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            string message = $"[{now}] [{Name}]: {MessageTbx.Text}";
            sendmsg(message);
            MessageTbx.Text = "";
        }

        private void Window_Closing(object sender, EventArgs e)
        {
            token = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();
            MainWindow main = new MainWindow();
                main.Show();
        }

        private void SendMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DateTime now = DateTime.Now;
                string message = $"[{now}] [{Name}]: {MessageTbx.Text}";
                sendmsg(message);
                MessageTbx.Text = "";
            }
        }
    }
}
