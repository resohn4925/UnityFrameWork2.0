using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClick : MonoBehaviour
{
    //[Tooltip("工具")]
    //[InspectorName("按钮列表")]
    [SerializeField]
    protected List<EnumClickEvent> enumClickEvent;
    [SerializeField]
    private List<Button> listButton;

    private void Start()
    {
        for(int i = 0; i < listButton.Count; ++i)
        {
            int index = i;
            listButton[i].onClick.AddListener(() =>
            {
                Onclick(index);
            });
        }
    }

    protected virtual void Onclick(int i)
    {
        for(int index = 0; index < enumClickEvent.Count; ++index)
        {
            EventManager.GetInstance().Trigger(ToString(index), i);
        }
    }

    protected string ToString(int i)
    {
        return enumClickEvent[i].ToString();
    }
}
