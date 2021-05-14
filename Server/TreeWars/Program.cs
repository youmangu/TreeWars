using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace TreeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipAddress = IPAddress.Parse("192.168.1.85");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 88);
            serverSocket.Bind(ipEndPoint);// 绑定ip和端口
            serverSocket.Listen(0); // 开始监听， 数字代表队列里可以监听的链接数，0 代表无限制
            Socket clientSocket =  serverSocket.Accept(); // 接受一个客户端连接

            // 向客户的发送消息
            string message = "Hello client! 你好...";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
            clientSocket.Send(data);

            // 接受客户端的消息
            byte[] buffer = new byte[1024];
            int count =  clientSocket.Receive(buffer);
            string msgReceive = System.Text.Encoding.UTF8.GetString(buffer, 0, count);
            Console.WriteLine(msgReceive);

            Console.ReadKey();
            clientSocket.Close();
            serverSocket.Close();
        }
    }
}
