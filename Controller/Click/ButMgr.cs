using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 由enumClickEvent触发；触发后移除所有Button
/// </summary>
public class ButMgr : SingletonMono<ButMgr>
{
    [SerializeField]
    private List<Button> listBut;
    private void Start()
    {
        EventManager.GetInstance().AddEventListener("FrozeBut", FrozeBut);
        EventManager.GetInstance().AddEventListener("UnFrozeBut", UnFrozeBut);
    }

    internal void UnFrozeBut(int index)
    {
        for(int i = 0; i < listBut.Count; ++i)
        {
            listBut[i].interactable = true;
        }
    }

    internal void FrozeBut(int index)
    {
        for (int i = 0; i < listBut.Count; ++i)
        {
            listBut[i].interactable = false;
        }
        Debug.Log("列表按钮禁用");
    }
}
