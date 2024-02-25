using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool
{
    private List<GameObject> listPoolObj;
    // private List<GameObject> listSceneObj;
    
    private int objCount;

    private Func<GameObject> generateMethod;
    
    private Action<GameObject> initMethod;


    public ObjPool(int objCount, Func<GameObject> generateMethod, Action<GameObject> initMethod)
    {
       this.objCount = objCount;
       this.generateMethod = generateMethod;
       this.initMethod = initMethod;
    }

    public void Init()
    {
        listPoolObj = new();
        // listSceneObj = new();
        for (int i = 0; i < objCount; ++i)
        {
            listPoolObj.Add(generateMethod?.Invoke());
            listPoolObj[i].gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 从对象池获取对象
    /// </summary>
    public void GetObj()
    {
        if (listPoolObj.Count > 0)
        {
            listPoolObj[listPoolObj.Count - 1].gameObject.SetActive(true);
            listPoolObj.RemoveAt(listPoolObj.Count - 1);
        }
        else
        {
            generateMethod?.Invoke();
        }
    }
    
    /// <summary>
    /// 回收对象
    /// </summary>
    public void PushObj(GameObject obj)
    {
        listPoolObj.Add(obj);
        obj.gameObject.SetActive(false);
        initMethod?.Invoke(obj);
    }
}
