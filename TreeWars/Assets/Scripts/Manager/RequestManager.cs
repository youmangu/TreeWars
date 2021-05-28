using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class RequestManager : BaseManager
{
    public RequestManager(GameFacade facade) : base(facade) { }

    private Dictionary<RequestCode, BaseRequest> requestList = new Dictionary<RequestCode, BaseRequest>();

    public void AddRequest(RequestCode requestCode, BaseRequest request)
    {
        requestList.Add(requestCode, request);
    }

    public void RemoveRequest(RequestCode requestCode)
    {
        requestList.Remove(requestCode);
    }

}
