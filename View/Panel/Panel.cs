using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : BasePanel
{
    protected override void Start()
    {
        base.Start();
        //EventManager.GetInstance().AddEventListener(ToString(0), ChangeObj);
    }

    protected virtual void OnDisable()
    {
        if(EventManager.GetInstance() != null)
        {
            EventManager.GetInstance().RemoveEventListener(ToString(0), ChangeObj);
        }
    }

    protected virtual void OnEnable()
    {
        EventManager.GetInstance().AddEventListener(ToString(0), ChangeObj);
    }
}
