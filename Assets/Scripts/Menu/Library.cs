using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    ItemManager Im;
    ItemList item;
    // Start is called before the first frame update
    private void Awake()
    {
        Im = GameObject.Find("Manager").GetComponent<ItemManager>();
        item = Im.GetItemList();
    }
    public void OpenMenu()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
