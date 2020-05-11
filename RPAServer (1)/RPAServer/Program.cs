using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace CoreServer
{
    class Program
    {

        static void Main(string[] args)
        {
            /*
            UdpClient client = new UdpClient(13000);
            client.Connect("127.0.0.1", 13001);
            Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"EXCEL\";\"CREATE\";\"c:/log/testfile.xlsx\";}");

            client.Send(sendBytes, sendBytes.Length);
            */
            
            Thread t = new Thread(delegate ()
            {
                // replace the IP with your system IP Address...
                Server myserver = new Server("127.0.0.1", 13001);
               // Server myServer = new Server("1", 2);
            });
            t.Start();

            Console.WriteLine("Server Started...!");
            
        }
    }
}
