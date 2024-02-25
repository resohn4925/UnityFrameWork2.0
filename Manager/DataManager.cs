using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// 数据的读取，存储，初始化；告诉所有面版数据更新了
/// </summary>
public class DataManager : SingletonMono<DataManager>
{
    private string SavePath => $"{Application.persistentDataPath}/save.json";//存档路径
    public Config config = new();
    public BagItem key = new(){itemID = 0};
    public BagItem ticket = new(){itemID = 1};
    //小游戏中的插槽
    public Slot slot0;
    public Slot slot1;
    public Slot slot2;
    public Slot slot3;
    public Slot slot4;
    public Slot slot5;
    public Slot slot6;
    private void Start()
    {
        EventManager.GetInstance().AddEventListener("SaveLoad", SaveLoad);
    }

    public void Init()
    {
        //初始化插槽
        slot0 = new(){slotID = 0, ballID = 0};
        slot1 = new(){slotID = 1, ballID = 6};
        slot2 = new(){slotID = 2, ballID = 5};
        slot3 = new(){slotID = 3, ballID = 4};
        slot4 = new(){slotID = 4, ballID = 3};
        slot5 = new(){slotID = 5, ballID = 2};
        slot6 = new(){slotID = 6, ballID = 1};
        //添加插槽
        config.listSlot.Clear();
        config.listSlot.Add(slot0);
        config.listSlot.Add(slot1);
        config.listSlot.Add(slot2);
        config.listSlot.Add(slot3);
        config.listSlot.Add(slot4);
        config.listSlot.Add(slot5);
        config.listSlot.Add(slot6);
        //添加插槽连线
        InitUnSe();
    }

    public void InitUnSe()//初始化无法序列化属性
    {
        config.listIntPairs.Add((0, 1));
        config.listIntPairs.Add((0, 2));
        config.listIntPairs.Add((0, 3));
        config.listIntPairs.Add((0, 4));
        config.listIntPairs.Add((0, 5));
        config.listIntPairs.Add((0, 6));
        config.listIntPairs.Add((1, 2));
        config.listIntPairs.Add((1, 3));
        config.listIntPairs.Add((1, 6));
        config.listIntPairs.Add((3, 4));
        config.listIntPairs.Add((4, 6));
        config.listIntPairs.Add((5, 6));
    }
    
    private void SaveLoad(int i)//新存档或继续
    {
        switch(i)
        {
            case 0://新档
                config = new();
                Init();
                EventManager.GetInstance().Trigger("DataUpdate", 0);//更新
                SaveData(config);
                break;
            case 1://读档
                config = LoadData();
                InitUnSe();
                EventManager.GetInstance().Trigger("DataUpdate", 0);//更新
                break;
            case 2://存档
                SaveData(config);
                Debug.Log("save");
                break;
        }
    }

    private Config LoadData()
    {
        if(File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            Config data = JsonUtility.FromJson<Config>(json);//存档
            return data;
        }
        else
        {
            Debug.Log("savenotfound");
            return null;
        }
    }

    private void SaveData(Config data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SavePath, json);//读档
    }
}

[System.Serializable]
public class Config//配置
{
    //道具总数
    public int sumItem;
    //当前道具ID
    public int currentItemID;
    //是否邮箱打开
    public bool isMailBoxOpen;
    //事件是否发生
    public bool isTicketEventOccur;
    public bool isGameFinish;
    //插槽连线列表
    public List<(int, int)> listIntPairs = new();
    //加入背包的道具列表
    public List<BagItem> listBagItem = new();
    //小游戏插槽列表
    public List<Slot> listSlot = new();
    public Config()
    {
        sumItem = 2;
        currentItemID = -1;
        isMailBoxOpen = false;
        isTicketEventOccur = false;
        isGameFinish = false;
    }
}

/// <summary>
/// 背包道具
/// </summary>
[System.Serializable]
public class BagItem
{
    public int itemID;
    public bool isUsed;
}

[System.Serializable]
public class Slot//小游戏中的插槽
{
    public int slotID;
    public int ballID;

    public Slot()
    {
    }
}