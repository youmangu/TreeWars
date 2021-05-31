using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;
using Common;


/// <summary>
/// 用来管理跟服务器端的链接
/// </summary>
public class ClientManager : BaseManager
{
    private const string IP = "127.0.0.1";
    private const int PORT = 6688;

    private Socket clientSocket;
    private Message msg = new Message();

    public ClientManager(GameFacade facade) : base(facade) { }

    public override void OnInit()
    {
        base.OnInit();

        clientSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(IP, PORT);
            Start();
        }
        catch (Exception e)
        {
            Debug.Log("无法与服务器建立链接：" + e.Message);
        }
    }

    private void Start()
    {
        clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, ReceiveMessage, null);
    }

    private void ReceiveMessage(IAsyncResult ar)
    {
        try
        {
            int count = clientSocket.EndReceive(ar);
            msg.ReadMessage(count, OnProcessData);
            Start();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    private void OnProcessData(RequestCode requestCode, string data)
    {

    }

    public void SendRequest(RequestCode requestCode, ActionCode actionCode, String data)
    {
        byte[] bytes = Message.PackData(requestCode, actionCode, data);
        clientSocket.Send(bytes);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();

        try
        {
            clientSocket.Close();
        }
        catch (Exception e)
        {
            Debug.Log("无法关闭客户端连接：" + e.Message);
        }
    }
}
