using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item", fileName = "Item")]
public class ItemData : ScriptableObject
{
    public string itemname;
    public int price;
    public string setumei;
    public int value;
    public ItemTag tag;
    public Plant plantData;
    public Sprite img;
    public bool IsGetItem = false;
    public void DataCopy(ItemData it)
    {
        itemname = it.itemname;
        price = it.price;
        setumei = it.setumei;
        value = it.value;
        tag = it.tag;
        plantData = it.plantData;
        img = it.img;
    }
}
