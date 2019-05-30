using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData : MonoBehaviour
{
    [SerializeField] public int money = 1000;
    [SerializeField] SaveLoad.SaveData sd;
    void Start()
    {
        SceneChange sc = GameObject.Find("SceneChenger").GetComponent<SceneChange>();
        sd = sc.GetSaveData();
        DataSet();
    }
    void DataSet()
    {
        money = sd.money;
        TimeCounter tc = GetComponent<TimeCounter>();
        tc.SetTime(sd.days, sd.hour, sd.second);
        GetComponent<ItemManager>().SetItemList(sd.itemvalues);
        GetComponent<Planter>().SetPlanters(sd.plantN,sd.plantG);
    }
}
