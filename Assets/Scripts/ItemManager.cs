//アイテム管理
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] ItemList item;
    // Start is called before the first frame update
    void Start()
    {
        StartItemGet();
    }
    //ゲーム開始時のアイテム処理
    void StartItemGet()
    {
        item.GetItemList().Clear();
        ItemData[] ia = Resources.LoadAll<ItemData>("Seed");
        for(int i = 0;i < ia.Length; i++)
        {
            ia[i].value = 0;
            item.GetItemList().Add(ia[i]);
        }
        ia = Resources.LoadAll<ItemData>("Plant");
        for (int i = 0; i < ia.Length; i++)
        {
            ia[i].value = 0;
            item.GetItemList().Add(ia[i]);
        }
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
    public void ChangeItemValue(ItemData it ,int value)
    {
        foreach(ItemData id in item.GetItemList())
        {
            if(id == it)
            {
                id.value += value;
                if(!id.IsGetItem)id.IsGetItem = true;
                return;
            }
        }
        Debug.Log("Item Error " + it.itemname + "　のデータが見つかりませんでした。");
    }
    //アイテム除去
    public void RemoveItem(int it)
    {
        item.GetItemList().RemoveAt(it);
    }

}
