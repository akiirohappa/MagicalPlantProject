﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planter : MonoBehaviour
{
    public Plant[] plantData;
    [SerializeField] Plant NowPlant;
    public GameObject[] plantPlane;
    Plant pl;
    int max = 16;
    public GameObject testobj;
    public GameObject uiObj;
    public LayerMask layerM;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject beforobj;
    Text uiname;
    Text uiGrowth;
    Text uiCanHv;
    ItemManager im;
    MenuManager Mm;
    [SerializeField] ItemData PlantItem;
    // Start is called before the first frame update
    void Start()
    {
        pl = ScriptableObject.CreateInstance<Plant>();
        plantData = new Plant[max];
        uiname = uiObj.transform.GetChild(0).GetComponent<Text>();
        uiGrowth = uiObj.transform.GetChild(1).GetComponent<Text>();
        uiCanHv = uiObj.transform.GetChild(2).GetComponent<Text>();
        im = GetComponent<ItemManager>();
        Mm = GetComponent<MenuManager>();
        for (int i = 0;i < max; i++)
        {
            plantData[i] = ScriptableObject.CreateInstance<Plant>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mm.GetMode() != MenuMode.None) if (Mm.GetMode() != MenuMode.ItemPlant) return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20f, layerM))
        {
            if(beforobj == null){
                uiObj.SetActive(true);
            }
            beforobj = hit.collider.gameObject;
            uiObj.transform.position = Input.mousePosition;
            GetPlantData(beforobj);
            UIDraw();
            if (NowPlant.statas == PlantStatas.Harvest && Input.GetMouseButtonDown(0))
            {
                Harvest(NowPlant);
            }
            if(NowPlant.statas == PlantStatas.None && Input.GetMouseButtonDown(0) && Mm.GetMode() == MenuMode.ItemPlant)
            {
                NowPlant.SetPlant(PlantItem.plantData, beforobj);
                PlantItem.value--;
                Mm.CloseMenu();
            }
        }
        else
        {
            uiObj.SetActive(false);
            NowPlant = null;
            beforobj = null;
        }
    }
    void GetPlantData(GameObject plant)
    {
        int num = -1;
        for(int i = 0;i < max; i++)
        {
            if (plant == plantPlane[i]) num = i;
        }
        if (num > -1) NowPlant = plantData[num];
    }
    void GetPlantPlane(GameObject plant)
    {
        int num = -1;
        for (int i = 0; i < max; i++)
        {
            if (plant == plantPlane[i]) num = i;
        }
        if (num > -1) NowPlant = plantData[num];
    }
    void UIDraw()
    {
        uiname.text = NowPlant.plantname;
        uiGrowth.text = "生育度：" + NowPlant.growth.ToString() + "%";
        if (NowPlant.statas == PlantStatas.Harvest) uiCanHv.gameObject.SetActive(true);
        else uiCanHv.gameObject.SetActive(false);
    }
    public void Growth()
    {
        for (int i = 0; i < max; i++)
        {
            if (plantData[i].statas == PlantStatas.NotGrowth)
            {
                plantData[i].growth += plantData[i].GrowthPlus;
                plantData[i].plantobj.transform.localScale = new Vector3(plantData[i].growth /100, plantData[i].growth / 100, plantData[i].growth / 100);
            }
            if (plantData[i].growth >= 100) plantData[i].statas = PlantStatas.Harvest;
        }
    }
    public void Harvest(Plant pl)
    {
        im.ChangeItemValue(pl.harvestItem, pl.harvestPlValue);
        pl.ResetPlant();
    }
    public void SetPlantItem(ItemData pl)
    {
        PlantItem = pl;
    }
    public Plant[] GetPlanters()
    {
        return plantData;
    }
}
