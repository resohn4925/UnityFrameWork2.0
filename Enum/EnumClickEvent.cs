using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumClickEvent
{
    //[InspectorName("")]
    PanelChanged,
    ButClick,
    SaveLoad,
    StartFade,//面板转场切换，当渐入结束的时候开始PanelChanged事件
    OpenMailBox,//邮箱打开
    AddItem,//加道具
    ChangeItemPanel,
    SelectItem,//选择道具
    DataUpdate,//面板更新
    Init,//面板初始化
    RemoveItem,//减道具
    HoldItem,
    Dialog,
    ChangeBGM,
    ChangeBallID,//改变小游戏的按钮ID
    GameReset,
    Exit
}

public enum ActiveValue
{
    Show,
    Hide
}

public enum BasePanelInterMode
{
    SingleSelec,
    MultiSelec
}