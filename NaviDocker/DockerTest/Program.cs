using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace DockerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var endPoint = new IPEndPoint(IPAddress.Any, 8000);
            var listener = new TcpListener(endPoint);
            listener.Server.Ttl = 255;
            listener.Server.NoDelay = true;
            listener.Server.DontFragment = true;
            Console.WriteLine("Starting listen.");
            listener.Start(1000);

            while (true)
            {               
                var client = listener.AcceptTcpClient();

                Console.WriteLine("Connection processed.");

                client.Client.Ttl = 255;
                client.Client.NoDelay = true;
                client.Client.DontFragment = true;

                var buf = new byte[1024];

                var length = client.Client.Receive(buf);

                Console.WriteLine($"Received {length} bytes.");
                Console.WriteLine();

                var str = System.Text.Encoding.UTF8.GetString(buf, 0, length);

                Console.WriteLine(str);

                client.Client.Send(Encoding.UTF8.GetBytes("HTTP/1.1 303 See Other"));

                client.Close();
                
            }

        }
    }
}
