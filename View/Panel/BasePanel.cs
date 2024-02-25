using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePanel : MonoBehaviour
{
    [SerializeField] protected List<GameObject> listObj;
    protected List<bool> butState = new();
    [SerializeField] private int initMode; //面板初始化，若为-2则全部隐藏，-1则全部显示，其他情况显示第n个值
    [SerializeField] private BasePanelInterMode interMode;
    [SerializeField] private List<EnumClickEvent> enumClickEvent;
    protected virtual void Start()
    {     
        PanelInit(initMode);
    }

    protected virtual void ChangeObj(int index)
    {
        switch (interMode)
        {
            case BasePanelInterMode.SingleSelec:
                for (int i = 0; i < listObj.Count; ++i)
                {
                    if (i == index)
                    {
                        Show(i);
                        butState[i] = true;
                    }
                    else
                    {
                        Hide(i);
                        butState[i] = false;
                    }
                }

                break;
            case BasePanelInterMode.MultiSelec:
                butState[index] = !butState[index];
                switch (butState[index])
                {
                    case true:
                        Show(index);
                        break;
                    case false:
                        Hide(index);
                        break;
                }

                break;
        }
    }

    protected internal void PanelInit(int index)
    {
        for (int i = 0; i < listObj.Count; ++i)
        {
            if (i < ButState.Count)
            {
                butState[i] = false;
            }
            else
            {
                butState.Add(false);
            }
        }
        
        switch (initMode)
        {
            case -2:
            {
                for (int i = 0; i < listObj.Count; ++i)
                {
                    Hide(i);
                }

                break;
            }
            case -1:
            {
                for (int i = 0; i < listObj.Count; ++i)
                {
                    Show(i);
                }

                break;
            }
            default:
            {
                for (int i = 0; i < listObj.Count; ++i)
                    if (initMode == i)
                    {
                        Show(i);
                    }
                    else
                    {
                        Hide(i);
                    }

                break;
            }
        }
    }


    protected void Hide(int i)
    {
        butState[i] = false;
        listObj[i].SetActive(false);
    }
    

    protected void Show(int i)
    {
        butState[i] = true;
        listObj[i].SetActive(true);
    }

    public List<bool> ButState
    {
        get { return butState; }
    }

    protected string ToString(int i)
    {
        if(enumClickEvent.Count != 0)
        {
            return enumClickEvent[i].ToString();
        }
        else
        {
            return "null";
        }
    }
}