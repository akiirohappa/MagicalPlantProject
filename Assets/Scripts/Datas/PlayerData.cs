using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] public int money = 1000;
    [SerializeField] public int days = 0;
    [SerializeField] public int hour = 7;
    [SerializeField] public int second = 0;
    [SerializeField] ItemManager im;
    [SerializeField] Plant[] plants;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
