using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Library : MonoBehaviour
{
    ItemManager Im;
    ItemList item;
    [SerializeField] GameObject list;
    [SerializeField] GameObject listPanel;
    [SerializeField] GameObject Setumei;
    // Start is called before the first frame update
    private void Awake()
    {
        Im = GameObject.Find("Manager").GetComponent<ItemManager>();
        
    }
    //メニューを開いた時の処理
    public void OpenMenu()
    {
        item = Im.GetItemList();
        List<ItemData> id = item.GetItemList();
        foreach(Transform child in list.transform)
        {
            Destroy(child.gameObject);
        }
        for(int i = 0;i < id.Count; i++)
        {
            if (id[i].IsGetItem) {
                GameObject Li =  Instantiate(listPanel, list.transform);
                Li.GetComponent<ShopItems>().it = id[i];
                Li.transform.GetChild(0).GetComponent<Text>().text = id[i].itemname;
                Li.transform.GetChild(1).GetComponent<Text>().text = "";
                Li.transform.GetChild(2).GetComponent<Image>().sprite = id[i].img;
            } 
        }
    }
    public void OpenItem(ItemData it)
    {
        Setumei.SetActive(true);
        Setumei.transform.GetChild(0).GetComponent<Image>().sprite = it.img;
        Setumei.transform.GetChild(1).GetComponent<Text>().text = it.itemname;
        Setumei.transform.GetChild(2).GetComponent<Text>().text = "";
        Setumei.transform.GetChild(3).GetComponent<Text>().text = it.setumei;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
