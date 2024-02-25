using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTargetPanel : OnClick
{
    public int targetPanel;

    protected override void Onclick(int index)
    {
        for(int i = 0; i < enumClickEvent.Count; ++i)
        {
            EventManager.GetInstance().Trigger(ToString(i), targetPanel);
            // Debug.Log("触发点击事件" + this.name);
        }
    }
}
