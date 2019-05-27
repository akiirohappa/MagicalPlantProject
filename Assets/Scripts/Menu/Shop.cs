using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
enum ShopStatas
{
    Buy,
    Sell,
    None,
}
public class Shop : MonoBehaviour
{
    ItemManager Im;
    PlayerData Pd;
    [SerializeField]ShopStatas SS;
    [SerializeField] ItemList MItems;
    [SerializeField]ItemList SItems;
    [SerializeField] string SItemList = "ShopItems";
    [SerializeField] ItemData selectItem;
    [SerializeField] GameObject ShopList;
    [SerializeField] GameObject ListBt;
    [SerializeField] GameObject Setumei;
    [SerializeField] GameObject TradePanel;
    int plusvalue;
    [SerializeField] int money;
    // Start is called before the first frame update
    void Start()
    {
        Pd = GameObject.Find("Manager").GetComponent<PlayerData>();
        Im = GameObject.Find("Manager").GetComponent<ItemManager>();
        GetShopItems();
    }
    void GetShopItems()
    {
        SItems = Resources.Load<ItemList>(SItemList);
        List<ItemData> il = new List<ItemData>();
        ItemData[] ia=     Resources.LoadAll<ItemData>("Seed");
        for(int i = 0;i < ia.Length; i++)
        {
            il.Add(ia[i]);
        }
        SItems.SetItemList(il);
    }
    //ショップメニューを開いた処理
    public void OpenShop()
    {
        money = Pd.money;
        SS = ShopStatas.None;
        SetSpBuy();
    }
    //ショップのアイテムリスト制作
    void SetShop(List<ItemData> id) {
        selectItem = null;
        Setumei.SetActive(false);
        TradePanel.SetActive(false);
        foreach (Transform child in ShopList.transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < id.Count; i++)
        {
            //種は売れないようにする
            if (SS == ShopStatas.Sell && id[i].tag == ItemTag.Seed) break;
            GameObject si = Instantiate(ListBt, ShopList.transform);
            si.GetComponent<ShopItems>().it = id[i];
            si.transform.GetChild(0).GetComponent<Text>().text = id[i].itemname;
            si.transform.GetChild(1).GetComponent<Text>().text = id[i].price.ToString() + "円";
            si.transform.GetChild(2).GetComponent<Image>().sprite = id[i].img;
        }
    }
    //ショップのアイテムリスト切り替え(購入)
    public void SetSpBuy()
    {
        if (SS == ShopStatas.Buy) return;
        SS = ShopStatas.Buy;
        SetShop(SItems.GetItemList());
    }
    //ショップのアイテムリスト切り替え(売却)
    public void SetSpSell()
    {
        if (SS == ShopStatas.Sell) return;
        SS = ShopStatas.Sell;
        MItems = Im.GetItemList();
        SetShop(MItems.GetItemList());
        
    }
    //リストのアイテム選択時
    public void OpenItem(ItemData it)
    {
        selectItem = it;
        Setumei.SetActive(true);
        Setumei.transform.GetChild(0).GetComponent<Image>().sprite = it.img;
        Setumei.transform.GetChild(1).GetComponent<Text>().text = it.itemname;
        Setumei.transform.GetChild(2).GetComponent<Text>().text = it.price.ToString() + "円";
        Setumei.transform.GetChild(3).GetComponent<Text>().text = it.setumei;
        if (SS == ShopStatas.Buy) Setumei.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "購入";
        else Setumei.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "売却";
    }
    //購入or売却
    public void StartTrede()
    {
        TradePanel.SetActive(true);
        plusvalue = 1;
        TradePanel.transform.GetChild(0).GetComponent<Text>().text = selectItem.itemname + "　を購入しますか？";
        TradeReset();
    }
    
    void TradeReset()
    {
        TradePanel.transform.GetChild(1).GetComponent<Text>().text = (selectItem.price * plusvalue).ToString();
        if ((selectItem.price * plusvalue) > money)
        {
            TradePanel.transform.GetChild(2).gameObject.SetActive(true);
            TradePanel.transform.GetChild(4).GetComponent<Button>().enabled = false;
        }
        else
        {
            TradePanel.transform.GetChild(2).gameObject.SetActive(false);
            TradePanel.transform.GetChild(4).GetComponent<Button>().enabled = true;
        }
        TradePanel.transform.GetChild(5).GetComponent<Text>().text = plusvalue.ToString();
    }
    public void SubmitTrade()
    {
        if (SS == ShopStatas.Buy) money -= (selectItem.price * plusvalue);
        else money -= (selectItem.price * plusvalue);
        Pd.money = money;
        Im.ChangeItemValue(selectItem, plusvalue);
        CancelTrade();
    }
    public void CancelTrade()
    {
        TradePanel.SetActive(false);
    }
    public void Changevalue(int num)
    {
        if (plusvalue == 1 && num < 0) return;
        else if (SS == ShopStatas.Buy && plusvalue == 999 && num > 0) return;
        else if (SS == ShopStatas.Sell && plusvalue == MItems.GetItemList()[MItems.GetItemList().IndexOf(selectItem)].value) return;
        plusvalue += num;
        TradeReset();
    }
}
