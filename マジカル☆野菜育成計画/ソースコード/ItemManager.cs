//----------------------------------------------------
//アイテム管理
//----------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
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
    //リスト取得（セーブ）
    public string GetSaveItem()
    {
        string str = "";
        for (int i = 0; i < item.GetItemList().Count; i++)
        {
            str += item.GetItemList()[i].value + ",";
        }
        str.TrimEnd(',');
        return str;
    }
    //リスト取得（通常）
    public ItemList GetItemList()
    {
        return item;
    }
    //リスト渡し
    public void SetItemList(string json)
    {
        StartItemGet();
        string[] il = json.Split(","[0]);
        Debug.Log(il[0]);
        for (int i = 0; i < il.Length-1; i++)
        {
            Debug.Log(il[i]);
            item.GetItemList()[i].value = Convert.ToInt32(il[i]);
        }
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
    
    public class SaveItem
    {
        public string itemname = "";
        public int value = 0;
        public SaveItem(string n,int v)
        {
            itemname = n;
            value = v;
        }
    }
}
