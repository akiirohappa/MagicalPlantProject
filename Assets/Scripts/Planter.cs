using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Planter : MonoBehaviour
{
    public Plant[] plantData;
    public GameObject[] plantPlane;
    Plant pl;
    int max = 16;
    public GameObject testobj;
    // Start is called before the first frame update
    void Start()
    {
        pl = ScriptableObject.CreateInstance<Plant>();
        plantData = new Plant[max];
        for(int i = 0;i < max; i++)
        {
            plantData[i] = ScriptableObject.CreateInstance<Plant>();
        }
        plantData[0].SetPlant("test", testobj,plantPlane[0],10);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Growth()
    {
        for (int i = 0; i < max; i++)
        {
            if (plantData[i].statas == PlantStatas.NotGrowth) plantData[i].growth += plantData[i].GrowthPlus;
            if (plantData[i].growth >= 100) plantData[i].statas = PlantStatas.Harvest;
        }
    }
}
