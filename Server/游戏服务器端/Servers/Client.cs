﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Common;
using MySql.Data.MySqlClient;
using GameServer.Tool;

namespace GameServer.Servers
{
    class Client
    {
        private Socket clientSocket;
        private Server server;
        private Message msg = new Message();

        private MySqlConnection mMysqlConnection;

        public Client() { }
        public Client(Socket socket, Server server)
        {
            this.clientSocket = socket;
            this.server = server;
            mMysqlConnection = ConnHelper.Connect();
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

                msg.ReadMessage(count, OnProcessMessage);
                Start();
            }
            catch (Exception e)
            {
                Close();
            }
        }

        private void OnProcessMessage(RequestCode requestCode, ActionCode actionCode, string data)
        {
            server.HandleRequest(requestCode, actionCode, data, this);
        }

        private void Close()
        {
            ConnHelper.CloseConnection(mMysqlConnection);
            if (clientSocket != null)
                clientSocket.Close();
            server.RemoveClient(this);
        }

        public void Send(RequestCode requestCode, string data)
        {
            byte[] bytes = Message.PackData(requestCode, data);
            clientSocket.Send(bytes);
        }
    }
}
