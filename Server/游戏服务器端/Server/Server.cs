using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace GameServer.Server
{
    class Server
    {
        private IPEndPoint ipPendPoint;
        private Socket serverSocket;
        private List<Client> clientList = new List<Client>();

        public Server() { }
        public Server(string ipStr, int port)
        {
            SetIpAndPort(ipStr, port);
        }

        public void SetIpAndPort(string ipStr, int port)
        {
            ipPendPoint = new IPEndPoint(IPAddress.Parse(ipStr), port);
        }

        public void Start()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(ipPendPoint);
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallBack, null);
        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            Socket clientSocket = serverSocket.EndAccept(ar);
            Client client = new Client(clientSocket, this);
            client.Start();
            clientList.Add(client);
        }

        public void RemoveClient(Client client)
        {
            lock (clientList)
            {
                clientList.Remove(client);
            }
            
        }

    }
}
