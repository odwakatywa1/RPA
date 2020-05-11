using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide
{
    class Program
    {
        static void Main(string[] args)
        {
            // This constructor arbitrarily assigns the local port number.
            UClient client = new UClient();
        }
    }
}
