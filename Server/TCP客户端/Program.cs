﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace TCP客户端
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.85"), 88));

            byte[] buffer = new byte[1024];
            int count = clientSocket.Receive(buffer);
            string s = Encoding.UTF8.GetString(buffer, 0, count);
            Console.WriteLine(s);


            string data = Console.ReadLine();
            clientSocket.Send(Encoding.UTF8.GetBytes(data));

            Console.ReadKey();
            clientSocket.Close();
        }
    }
}
