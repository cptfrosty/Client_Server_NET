using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TrainingNET
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress localAdr = IPAddress.Parse("127.0.0.1");
            int port = 8888;
            TcpListener server = new TcpListener(localAdr, port);
            server.Start();
        }
    }
}
