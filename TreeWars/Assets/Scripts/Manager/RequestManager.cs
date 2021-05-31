using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class RequestManager : BaseManager
{
    public RequestManager(GameFacade facade) : base(facade) { }

    private Dictionary<RequestCode, BaseRequest> requestDic = new Dictionary<RequestCode, BaseRequest>();

    public void AddRequest(RequestCode requestCode, BaseRequest request)
    {
        requestDic.Add(requestCode, request);
    }

    public void RemoveRequest(RequestCode requestCode)
    {
        requestDic.Remove(requestCode);
    }

    public void HandleResponse(RequestCode requestCode, string data)
    {
        BaseRequest request = requestDic.TryGet<RequestCode, BaseRequest>(requestCode);
        if (request == null)
        {
            Debug.LogWarning("无法获取requestcode " + requestCode + "对用的request类"); return;
        }

        request.OnResponse(data);
    }

}
