using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemTag
{
    Seed,
    Plant,
}
public class ItemList : MonoBehaviour
{
    [SerializeField]List<ItemData> myItem;
    // Start is called before the first frame update
    void Start()
    {
        myItem = new List<ItemData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    List<ItemData> GetItemList()
    {
        return myItem;
    }
    void SetItemList(List<ItemData> it)
    {
        myItem = it;
    }
    void SetItemList(ItemData it)
    {
        myItem.Add(it);
    }
}
