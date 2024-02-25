using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : SingletonMono<EventManager>
{
    private Dictionary<string, UnityAction<int>> eventDic = new();

    public void AddEventListener(string name, UnityAction<int> action)
    {
        if(name != "null")
        {
            if (eventDic.ContainsKey(name))
            {
                eventDic[name] += action;
            }

            else
            {
                eventDic.Add(name, action);
            }
        }
    }
    public void RemoveEventListener(string name, UnityAction<int> action)
    {
        if (eventDic.ContainsKey(name))
        {
            eventDic[name] -= action;
        }
    }

    public void Trigger(string name, int index)
    {
        if (eventDic.ContainsKey(name))
        {
            if(eventDic[name] != null)
            {
                eventDic[name].Invoke(index);
            }
        }
    }
}
