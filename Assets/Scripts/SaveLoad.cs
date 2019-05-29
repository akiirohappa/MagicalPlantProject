using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    [SerializeField]PlayerData PlData;




    // Start is called before the first frame update
    void Start()
    {
        PlData = GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save()
    {
        TimeCounter tc = GetComponent<TimeCounter>();
        PlData.days = tc.GetTime().day;
        PlData.hour = tc.GetTime().hour;
        PlData.second = tc.GetTime().second;
        PlData.il = GetComponent<ItemManager>().GetItemList();
        PlData.plants = GetComponent<Planter>().GetPlanters();
        PlData.Cd = GameObject.Find("Option").GetComponent<Option>().GetConfigData();
    }
}
