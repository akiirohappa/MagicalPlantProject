using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItems : MonoBehaviour
{
    [SerializeField] string ShopFName;
    [SerializeField] string ItemFName;
    [SerializeField] MenuManager im;
    [SerializeField]public ItemData it;
    private void Awake()
    {
       im = GameObject.Find("Manager").GetComponent<MenuManager>();
    }
    public void OnClick()
    {
        if(im.GetMode() == MenuMode.Shop)GameObject.Find(ShopFName).GetComponent<ShopandItem>().OpenItem(it);
        else GameObject.Find(ItemFName).GetComponent<ShopandItem>().OpenItem(it);
    }
}
