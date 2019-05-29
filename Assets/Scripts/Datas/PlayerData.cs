using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] public int money = 1000;
    [SerializeField] public int days = 0;
    [SerializeField] public int hour = 7;
    [SerializeField] public float second = 0;
    [SerializeField] public ItemList il;
    [SerializeField] public Plant[] plants;
    [SerializeField] public ConfigData Cd;
}
