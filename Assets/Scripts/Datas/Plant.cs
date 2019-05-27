using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlantStatas
{
    None,
    NotGrowth,
    Growth,
    Harvest
}
[CreateAssetMenu(menuName = "Data/Plant", fileName = "Plant")]
public class Plant : ScriptableObject
{
    public string plantname = "空";
    public float growth = 0f;
    public float GrowthPlus;
    public GameObject plantobj;
    public PlantStatas statas = PlantStatas.None;
    public ItemData harvestItem;
    public int harvestPlValue;
    public Plant()
    {
        statas = PlantStatas.None;
        growth = 0f;
    }
    public void SetPlant(string name,GameObject obj,GameObject pos,float plus)
    {
        plantname = name;
        plantobj = Instantiate(obj,pos.transform);
        GrowthPlus = plus;
        statas = PlantStatas.NotGrowth;
    }
    public void SetPlant(Plant pl, GameObject pos)
    {
        plantname = pl.plantname ;
        plantobj = Instantiate(pl.plantobj, pos.transform);
        GrowthPlus = pl.GrowthPlus;
        growth = 0;
        statas = PlantStatas.NotGrowth;
        harvestItem = pl.harvestItem;
        harvestPlValue = pl.harvestPlValue;
    }
    public void ResetPlant()
    {
        plantname = "空";
        Destroy(plantobj);
        GrowthPlus = 0;
        growth = 0;
        statas = PlantStatas.None;
    }
}
