using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItems : MonoBehaviour
{
    [SerializeField] string ShopFName;
    [SerializeField]public ItemData it;
    public void OnClick()
    {
        GameObject.Find(ShopFName).GetComponent<Shop>().OpenItem(it);
    }
}
