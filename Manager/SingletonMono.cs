using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    
    public static T GetInstance()//如果这个方法在实例化前被调用，则实例化
    {
        if(instance == null)
        {
            instance = FindObjectOfType<T>();
            //Debug.Log(instance.name);
        }
        return instance;
    }
    
    protected virtual void Awake()
    {
        instance = this as T;
    }
}