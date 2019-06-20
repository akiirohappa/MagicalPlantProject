using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemTag
{
    Seed,
    Plant,
}
[CreateAssetMenu (menuName ="ItemList" ,fileName ="ItemList")]
public class ItemList : ScriptableObject
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
    public void SetItemList(List<ItemData> it)
    {
        myItem = it;
    }
    public List<ItemData> GetItemList()
    {
        return myItem;
    }
}
