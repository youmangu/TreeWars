using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    private UIManager uiMng;
    private AudioManager audioMng;
    private PlayerManger playerMng;
    private CameraManager cameraMng;
    private RequestManager requestMng;

    private ClientManager clientMng;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void InitManager()
    {
        uiMng = new UIManager();
        audioMng = new AudioManager();
        playerMng = new PlayerManger();
        cameraMng = new CameraManager();
        requestMng = new RequestManager();
        clientMng = new ClientManager();

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

}
