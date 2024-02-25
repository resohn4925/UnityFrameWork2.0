using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BaseFade : MonoBehaviour
{
    //要fade的物件序列
    [SerializeField]
    protected List<GameObject> listObj;
    //渐变速率
    private float _fadeSpeed = 2f;
    //渐入
    protected bool _isFadeIn;
    //渐出
    protected bool _isFadeOut;
    [SerializeField]
    protected FadeMode fadeMode;
    //要fade的物件id
    private int _objID;

    protected virtual void Awake()
    {
        switch (fadeMode)
        {
            case FadeMode.FadeIn:
                // foreach (GameObject gameObj in listObj)
                // {
                //     gameObject.GetComponent<CanvasGroup>().alpha = 0f;
                // }
                listObj[0].GetComponent<CanvasGroup>().alpha = 0f;
                break;
            case FadeMode.FadeOut:
                // foreach (GameObject gameObj in listObj)
                // {
                //     gameObject.GetComponent<CanvasGroup>().alpha = 1f;
                // }
                listObj[0].GetComponent<CanvasGroup>().alpha = 1f;
                break;
            case FadeMode.FadeInAndFadeOut:
                break;
        }
    }

    private void Start()
    {
        // EventManager.GetInstance().AddEventListener("StartFade", StartFade);
    }

    private void Update()
    {
        Fade();
    }
    
    protected void StartFade(int i)
    {
        _objID = i;
        switch (fadeMode)
        {
            case FadeMode.FadeIn:
                _isFadeIn = true;
                _isFadeOut = false;
                listObj[_objID].SetActive(true);
                break;
            case FadeMode.FadeOut:
                _isFadeIn = false;
                _isFadeOut = true;
                break;
            case FadeMode.FadeInAndFadeOut:
                StartFadeInAndFadeOut(i);
                break;
        }
    }

    protected virtual void StartFadeInAndFadeOut(int i)
    {
        //这里写渐入渐出的初始化方法
    }
    
    private void Fade()
    {
        switch (fadeMode)
        {
            case FadeMode.FadeIn:
                if (_isFadeIn)
                {
                    FadeIn(_objID);
                    if (listObj[_objID].GetComponent<CanvasGroup>().alpha > 0.999f)
                    {
                        _isFadeIn = false;
                    }
                }
                else
                {
                    break;
                }
                break;
            case FadeMode.FadeOut:
                if (_isFadeOut)
                {
                    FadeOut(_objID);
                    if (listObj[_objID].GetComponent<CanvasGroup>().alpha < 0.001f)
                    {
                        _isFadeIn = false;
                        listObj[_objID].SetActive(false);
                    }
                }
                else
                {
                    break;
                }
                break;
            case FadeMode.FadeInAndFadeOut:
                FadeInAndFadeOut();
                break;
        }
    }
    
    protected virtual void FadeInAndFadeOut()
    {
        //这里写渐入渐出的实现方法
    }

    protected virtual void FadeOver()
    {
        //渐入/渐出结束了，这里写要触发的事件
        // EventManager.GetInstance().Trigger("PanelChanged", _panelID);
    }
    
    protected void FadeIn(int i)
    {
        listObj[i].GetComponent<CanvasGroup>().alpha += _fadeSpeed*Time.deltaTime;
    }
    
    protected void FadeOut(int i)
    {
        listObj[i].GetComponent<CanvasGroup>().alpha -= _fadeSpeed*Time.deltaTime;
    }
}

public enum FadeMode
{
    FadeIn,
    FadeOut,
    FadeInAndFadeOut
}
