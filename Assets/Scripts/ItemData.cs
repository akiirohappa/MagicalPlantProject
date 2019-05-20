using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Item", fileName = "Item")]
public class ItemData : ScriptableObject
{
    public string itemname;
    public int price;
    public string setumei;
    public ItemTag tag;
    public Plant plantData;
}
