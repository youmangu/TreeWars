using System.Collections;
using System.Collections.Generic;

public class BaseManager 
{
    protected GameFacade facade;
    public BaseManager(GameFacade facade) { this.facade = facade; }
    public virtual void OnInit() { }
    public virtual void OnDestroy() { }
}
