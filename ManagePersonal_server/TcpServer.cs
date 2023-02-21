using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ManagePersonal_server
{
    public class TcpServer
    {
        public void StartListening(string ip, int port)
        {
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(5);

            Console.WriteLine($"Server started at {ip}:{port}");

            while (true)
            {
                var listener = tcpSocket.Accept();
                var buffer = new byte[256];
                var size = 0;
                var data = new StringBuilder();

                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));

                } while (listener.Available > 0);

                Console.WriteLine("Received data: " + data);

                listener.Send(Encoding.UTF8.GetBytes("Success"));

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
        }
    }
}