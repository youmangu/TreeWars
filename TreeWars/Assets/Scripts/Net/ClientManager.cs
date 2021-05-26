using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;

/// <summary>
/// 用来管理跟服务器端的链接
/// </summary>
public class ClientManager : BaseManager
{
    private const string IP = "127.0.0.1";
    private const int PORT = 6688;

    private Socket clientSocket;

    public override void OnInit()
    {
        base.OnInit();

        clientSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(IP, PORT);
        }
        catch (Exception e)
        {
            Debug.Log("无法与服务器建立链接：" + e.Message);
        }
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
