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
public class Plant : ScriptableObject
{
    public string plantname;
    public float growth;
    public float GrowthPlus;
    public GameObject plantobj;
    public PlantStatas statas;
    public Plant()
    {
        statas = PlantStatas.None;
        growth = 0f;
    }
    public void SetPlant(string name,GameObject obj,GameObject pos,float plus)
    {
        plantname = name;
        plantobj = Instantiate(obj,pos.transform);
        growth = 0f;
        GrowthPlus = plus;
        statas = PlantStatas.NotGrowth;
    }
    public void Harvest()
    {
        statas = PlantStatas.None;
        growth = 0f;
    }
    
}
