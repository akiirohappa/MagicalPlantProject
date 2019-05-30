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
public class ShopandItem : MonoBehaviour
{
    ItemManager Im;
    PlayerData Pd;
    MenuManager Mm;
    Planter Pl ;
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
    AudioManager am;
    // Start is called before the first frame update
    void Awake()
    {
        am = GameObject.Find("SceneChenger").GetComponent<AudioManager>();
        Pd = GameObject.Find("Manager").GetComponent<PlayerData>();
        Im = GameObject.Find("Manager").GetComponent<ItemManager>();
        Mm = GameObject.Find("Manager").GetComponent<MenuManager>();
        Pl = GameObject.Find("Manager").GetComponent<Planter>();
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
    //メニューを開いた処理(ショップ、アイテム兼用)
    public void OpenShop()
    {
        money = Pd.money;
        SS = ShopStatas.None;
        if (Mm.GetMode() == MenuMode.Shop)
        {
            SetSpBuy();
        }
        else
        {
            SetSpSell();
            SS = ShopStatas.None;
        }
    }
    //リストのアイテム選択時(ショップ、アイテム兼用)
    public void OpenItem(ItemData it)
    {
        am.PlaySE(am.SE[0]);
        selectItem = it;
        Setumei.SetActive(true);
        Setumei.transform.GetChild(0).GetComponent<Image>().sprite = it.img;
        Setumei.transform.GetChild(1).GetComponent<Text>().text = it.itemname;
        Setumei.transform.GetChild(2).GetComponent<Text>().text = it.price.ToString() + "円";
        if (Mm.GetMode() == MenuMode.Shop) Setumei.transform.GetChild(2).GetComponent<Text>().text = it.price.ToString() + "円" + "\n" + it.value.ToString() + "個";
        else Setumei.transform.GetChild(2).GetComponent<Text>().text = it.value.ToString() + "個";
        Setumei.transform.GetChild(3).GetComponent<Text>().text = it.setumei;
        if(Mm.GetMode() == MenuMode.Item)
        {
            if (it.tag == ItemTag.Plant || it.value == 0)
            {
                Setumei.transform.GetChild(4).gameObject.SetActive(false);
            }
            else
            {
                Setumei.transform.GetChild(4).gameObject.SetActive(true);
                Setumei.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "植える";
            }
        }
        if (Mm.GetMode() == MenuMode.Shop)
        {
            if(SS == ShopStatas.Buy) Setumei.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "購入";
            else Setumei.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "売却";
        }
    }
    //アイテムリスト制作(ショップ、アイテム兼用)
    void SetShop(List<ItemData> id)
    {
        selectItem = null;
        Setumei.SetActive(false);
        TradePanel.SetActive(false);
        foreach (Transform child in ShopList.transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < id.Count; i++)
        {
            GameObject si;
            //種は売れないようにする
            if (Mm.GetMode() == MenuMode.Shop && SS == ShopStatas.Sell)
            {
                if (id[i].tag == ItemTag.Seed || id[i].value == 0)
                {

                }
                else
                {
                    si = Instantiate(ListBt, ShopList.transform);
                    si.GetComponent<ShopItems>().it = id[i];
                    si.transform.GetChild(0).GetComponent<Text>().text = id[i].itemname;
                    if (Mm.GetMode() == MenuMode.Shop) si.transform.GetChild(1).GetComponent<Text>().text = id[i].price.ToString() + "円";
                    else si.transform.GetChild(1).GetComponent<Text>().text = id[i].value.ToString() + "個";
                    si.transform.GetChild(2).GetComponent<Image>().sprite = id[i].img;
                }
            }
            else
            {
                if(id[i].value != 0 || SS == ShopStatas.Buy)
                {
                    si = Instantiate(ListBt, ShopList.transform);
                    si.GetComponent<ShopItems>().it = id[i];
                    si.transform.GetChild(0).GetComponent<Text>().text = id[i].itemname;
                    if (Mm.GetMode() == MenuMode.Shop) si.transform.GetChild(1).GetComponent<Text>().text = id[i].price.ToString() + "円";
                    else si.transform.GetChild(1).GetComponent<Text>().text = id[i].value.ToString() + "個";
                    si.transform.GetChild(2).GetComponent<Image>().sprite = id[i].img;
                }
            }
        }
    }
    //----------------------------------------------
    //ショップ部分
    //----------------------------------------------
    //ショップのアイテムリスト切り替え(購入)(ショップ)
    public void SetSpBuy()
    {
        am.PlaySE(am.SE[0]);
        SS = ShopStatas.Buy;
        SetShop(SItems.GetItemList());
    }
    //ショップのアイテムリスト切り替え(売却)(ショップ)
    public void SetSpSell()
    {
        am.PlaySE(am.SE[0]);
        SS = ShopStatas.Sell;
        MItems = Im.GetItemList();
        SetShop(MItems.GetItemList());
    }
    //購入or売却(ショップ)
    public void StartTrede()
    {
        am.PlaySE(am.SE[0]);
        TradePanel.SetActive(true);
        plusvalue = 1;
        TradePanel.transform.GetChild(0).GetComponent<Text>().text = selectItem.itemname + "　を" + ((SS == ShopStatas.Buy)? "購入":"売却")+ "しますか？";
        TradeReset();
    }
    void TradeReset()
    {
        am.PlaySE(am.SE[1]);
        TradePanel.transform.GetChild(1).GetComponent<Text>().text = (selectItem.price * plusvalue).ToString();
        if ((selectItem.price * plusvalue) > money && SS == ShopStatas.Buy)
        {
            TradePanel.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            TradePanel.transform.GetChild(2).gameObject.SetActive(false);
        }
        TradePanel.transform.GetChild(5).GetComponent<Text>().text = plusvalue.ToString();
    }
    public void SubmitTrade()
    {
        
        if (SS == ShopStatas.Buy)
        {
            if((selectItem.price * plusvalue) > money)
            {
                am.PlaySE(am.SE[1]);
                return;
            }
            money -= (selectItem.price * plusvalue);
            Im.ChangeItemValue(selectItem, plusvalue);
        }
        else
        {
            money += (selectItem.price * plusvalue);
            Im.ChangeItemValue(selectItem, -plusvalue);
            SetSpSell();
        }
        am.PlaySE(am.SE[4]);
        Pd.money = money;
        CancelTrade();
    }
    public void CancelTrade()
    {
        am.PlaySE(am.SE[1]);
        TradePanel.SetActive(false);
    }
    public void Changevalue(int num)
    {
        am.PlaySE(am.SE[0]);
        if (plusvalue == 1 && num < 0) return;
        else if (SS == ShopStatas.Buy && plusvalue == 999 && num > 0) return;
        else if (SS == ShopStatas.Sell && plusvalue == MItems.GetItemList()[MItems.GetItemList().IndexOf(selectItem)].value) return;
        plusvalue += num;
        TradeReset();
    }
    //----------------------------------------------
    //アイテム部分
    //----------------------------------------------
    //植えるボタン押したとき
    public void StartPlant()
    {
        am.PlaySE(am.SE[0]);
        Pl.SetPlantItem(selectItem);
    }

}
