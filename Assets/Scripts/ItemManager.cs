using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] ItemList item;
    // Start is called before the first frame update
    void Start()
    {

    }
    //リスト取得
    public ItemList GetItemList()
    {
        return item;
    }
    //アイテム取得(インデックス)
    public int GetItem(ItemData it)
    {
        return item.GetItemList().IndexOf(it);
    }
    //アイテム取得（アイテムクラス）
    public ItemData GetItem(int i)
    {
        return item.GetItemList()[i];
    }
    //アイテム要素数取得
    public int GetMax()
    {
        return item.GetItemList().Count;
    }
    //アイテム追加
    public void AddItemList(ItemData it ,int value)
    {
        foreach(ItemData id in item.GetItemList())
        {
            if(id == it)
            {
                id.value += value;
                return;
            }
        }
        //ItemData itemsa = ScriptableObject.CreateInstance<ItemData>();
        //itemsa.DataCopy(it);
        item.GetItemList().Add(it);
    }
    //アイテム除去
    public void RemoveItem(int it)
    {
        item.GetItemList().RemoveAt(it);
    }

}
