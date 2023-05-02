using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
using static System.Net.Mime.MediaTypeNames;

namespace Messenger
{
    public partial class TcpClient : Window
    {
        private Socket socket;
        public static string Name;
        public static string IPServer = "";

        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private CancellationToken token;
        public TcpClient()
        {
            InitializeComponent();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.ConnectAsync(IPServer, 8888);

            ReceiveMessage();
        }

        private async Task ReceiveMessage()
        {
            while (!token.IsCancellationRequested)
            {
                byte[] bytes = new byte[1024];
                await socket.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                MessagesList.Items.Add(message);
            }
        }

        private async Task sendmsg(string msg)
        {
            if (!token.IsCancellationRequested)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(msg);
                await socket.SendAsync(bytes, SocketFlags.None);
            }
        }

        private void ExitBt_Click(object sender, RoutedEventArgs e)
        {
            token = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();
            socket.Close();
            this.Close();
        }

        private void SendBt_Click(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            string message = $"[{now}] [{Name}]: {MessageTbx.Text}";
            sendmsg(message);
            MessageTbx.Text = null;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
                MessageTbx.Text = null;
            }
        }
    }
}
