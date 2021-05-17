using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace GameServer.Server
{
    class Client
    {
        private Socket clientSocket;
        private Server server;
        private Message msg = new Message();

        public Client() { }
        public Client(Socket socket, Server server)
        {
            this.clientSocket = socket;
            this.server = server;
        }

        public void Start()
        {
            clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, ReceiveCallBack, null);
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                int count = clientSocket.EndReceive(ar);
                if (count == 0)
                {
                    Close();
                }

                msg.ReadMessage(count);
                Start();
            }
            catch (Exception e)
            {
                Close();
            }

            
        }

        private void Close()
        {
            if (clientSocket != null)
                clientSocket.Close();
            server.RemoveClient(this);
        }
    }
}
