using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ManagePersonal_server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 5000;

            var server = new TcpServer();
            server.StartListening(ip, port);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            
        }
    }
}
