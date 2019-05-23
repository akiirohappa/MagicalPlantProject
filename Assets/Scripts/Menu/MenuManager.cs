using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

enum MenuMode
{
    None,
    Item,
    Shop,
    Log,
    Config,
}
public class MenuManager : MonoBehaviour
{
    public GameObject BackButton;
    [SerializeField] Text moneyText;
    PlayerData pl;
    [SerializeField] GameObject Shop;

    // Start is called before the first frame update
    void Start()
    {
        pl = GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = pl.money.ToString() + "円";
    }
    public void OpenShop()
    {
        EventSystem.current.SetSelectedGameObject(null);
        Shop.SetActive(true);
        Shop.GetComponent<Animator>().SetTrigger("Open");
        BackButton.SetActive(true);
        Shop.GetComponent<Shop>().OpenShop();
    }
    public void CloseMenu()
    {
        BackButton.SetActive(false);
    }
}
