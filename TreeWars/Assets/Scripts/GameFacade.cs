using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class GameFacade : MonoBehaviour
{
    private static GameFacade _instance;
    public static GameFacade Instance { get { return _instance; } }

    private UIManager uiMng;
    private AudioManager audioMng;
    private PlayerManger playerMng;
    private CameraManager cameraMng;
    private RequestManager requestMng;

    private ClientManager clientMng;



    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(_instance);
        }
        _instance = this;
    }

    private void InitManager()
    {
        uiMng = new UIManager(this);
        audioMng = new AudioManager(this);
        playerMng = new PlayerManger(this);
        cameraMng = new CameraManager(this);
        requestMng = new RequestManager(this);
        clientMng = new ClientManager(this);

        uiMng.OnInit();
        audioMng.OnInit();
        playerMng.OnInit();
        cameraMng.OnInit();
        requestMng.OnInit();
        clientMng.OnInit();
    }

    private void DestroyManager()
    {
        uiMng.OnDestroy();
        audioMng.OnDestroy();
        playerMng.OnDestroy();
        cameraMng.OnDestroy();
        requestMng.OnDestroy();
        clientMng.OnDestroy();
    }

    private void OnDestroy()
    {
        DestroyManager();
    }

    public void AddRequest(RequestCode requestCode, BaseRequest request)
    {
        requestMng.AddRequest(requestCode, request);
    }

    public void RemoveRequest(RequestCode requestCode)
    {
        requestMng.RemoveRequest(requestCode);
    }

    public void HandleResponse(RequestCode requestCode, string data)
    {
        requestMng.HandleResponse(requestCode, data);
    }

}
