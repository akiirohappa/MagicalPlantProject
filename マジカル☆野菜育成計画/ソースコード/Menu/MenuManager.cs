using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum MenuMode
{
    None,
    Item,
    ItemPlant,
    Shop,
    Log,
    Config,
}
public class MenuManager : MonoBehaviour
{
    public GameObject BackButton;
    public GameObject BackButtonTx;
    [SerializeField] Text moneyText;
    PlayerData pl;
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject Item;
    [SerializeField] GameObject Library;
    [SerializeField] GameObject Config;
    MenuMode MM;
    AudioManager am;
    // Start is called before the first frame update
    void Start()
    {
        am = GameObject.Find("SceneChenger").GetComponent<AudioManager>();
        am.PlayBgm(am.BGM[1]);
        pl = GetComponent<PlayerData>();
        MM = MenuMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = pl.money.ToString() + "円";
    }
    public void OpenItem()
    {
        am.PlaySE(am.SE[0]);
        if (MM == MenuMode.Item) return;
        CloseMenu();
        MM = MenuMode.Item;
        EventSystem.current.SetSelectedGameObject(null);
        Item.SetActive(true);
        Item.GetComponent<Animator>().SetTrigger("Open");
        BackButton.SetActive(true);
        BackButtonTx.SetActive(true);
        Item.GetComponent<ShopandItem>().OpenShop();
    }
    public void OpenShop()
    {
        am.PlaySE(am.SE[0]);
        if (MM == MenuMode.Shop) return;
        CloseMenu();
        MM = MenuMode.Shop;
        EventSystem.current.SetSelectedGameObject(null);
        Shop.SetActive(true);
        Shop.GetComponent<Animator>().SetTrigger("Open");
        BackButton.SetActive(true);
        BackButtonTx.SetActive(true);
        Shop.GetComponent<ShopandItem>().OpenShop();
    }
    public void OpenLibrary()
    {
        am.PlaySE(am.SE[0]);
        if (MM == MenuMode.Log) return;
        CloseMenu();
        MM = MenuMode.Log;
        EventSystem.current.SetSelectedGameObject(null);
        Library.SetActive(true);
        Library.GetComponent<Animator>().SetTrigger("Open");
        BackButton.SetActive(true);
        BackButtonTx.SetActive(true);
        Library.GetComponent<Library>().OpenMenu();
    }
    public void OpenConfig()
    {
        am.PlaySE(am.SE[0]);
        if (MM == MenuMode.Config) return;
        CloseMenu();
        MM = MenuMode.Config;
        EventSystem.current.SetSelectedGameObject(null);
        Config.SetActive(true);
        Config.GetComponent<Animator>().SetTrigger("Open");
        BackButton.SetActive(true);
        BackButtonTx.SetActive(true);
        GetComponent<Option>().OpenMenu();
    }
    public void CloseMenu()
    {
        am.PlaySE(am.SE[1]);
        switch (MM)
        {
            case MenuMode.Shop:
                MM = MenuMode.None;
                Shop.GetComponent<Animator>().SetTrigger("Close");
                break;
            case MenuMode.Item:
                MM = MenuMode.None;
                Item.GetComponent<Animator>().SetTrigger("Close");
                break;
            case MenuMode.ItemPlant:
                MM = MenuMode.None;
                break;
            case MenuMode.Log:
                MM = MenuMode.None;
                Library.GetComponent<Animator>().SetTrigger("Close");
                break;
            case MenuMode.Config:
                MM = MenuMode.None;
                GetComponent<Option>().CloseMenu();
                Config.GetComponent<Animator>().SetTrigger("Close");
                break;
        }
        BackButton.SetActive(false);
        BackButtonTx.SetActive(false);
    }
    public void PlantStart()
    {
        am.PlaySE(am.SE[0]);
        Item.SetActive(false);
        Item.GetComponent<Animator>().SetTrigger("Close");
        MM = MenuMode.ItemPlant;
    }
    public MenuMode GetMode()
    {
        return MM;
    }
}
