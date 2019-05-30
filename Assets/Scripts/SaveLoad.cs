//-----------------------------------------------
//セーブ・ロード用
//-----------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

//ファイル表示用。
enum SLType
{
    Save,
    Load
}
//選択がどの段階まで進んだか
public enum NowPosition
{
    None,
    SelectFile,
    Arart,
    Done
}
public class SaveLoad : MonoBehaviour
{
    [SerializeField]PlayerData PlData;
    [SerializeField] const string savefile = "SaveData";
    [SerializeField] const string filepu = "Config.txt";
    [SerializeField] const string file00 = "Save00.txt";
    [SerializeField] const string file01 = "Save01.txt";
    [SerializeField] const string file02 = "Save02.txt";
    [SerializeField] const string file03 = "Save03.txt";
    [SerializeField] const string file04 = "Save04.txt";
    [SerializeField] const string file05 = "Save05.txt";
    [SerializeField] GameObject SavePanel;
    [SerializeField] GameObject ArartPanel;
    [SerializeField] GameObject DonePanel;
    [SerializeField] int SaveFNum;
    bool IsnullF;
    [SerializeField] NowPosition pos;
    [SerializeField] SLType type;
    SaveData save;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void CloseMenu()
    {
        pos = NowPosition.None;
        Cancel();
    }
    public void StartSave()
    {
        type = SLType.Save;
        SavePanel.SetActive(true);
                        DonePanel.SetActive(false);
                ArartPanel.SetActive(false);
        SaveFNum = 1;
        pos = NowPosition.SelectFile;
        SaveDataDisplay(SaveFNum);
    }
    public void StartLoad()
    {
        type = SLType.Load;
        SavePanel.SetActive(true);
        SaveFNum = 0;
        pos = NowPosition.SelectFile;
        SaveDataDisplay(SaveFNum);
    }
    //セーブデータを画面に表示
    public void SaveDataDisplay(int fileNum)
    {
        SaveData pl = Load(fileNum);
        SavePanel.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = "ファイル" + fileNum;
        if(pl != null)
        {
            IsnullF = false;
            SavePanel.transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
            SavePanel.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
            SavePanel.transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(true);
            SavePanel.transform.GetChild(0).transform.GetChild(5).gameObject.SetActive(false);
            SavePanel.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>().text = pl.days.ToString() + "日目";
            SavePanel.transform.GetChild(0).transform.GetChild(3).GetComponent<Text>().text = pl.hour.ToString() + "：" + ((((int)pl.second) < 10) ? "0"+ ((int)pl.second).ToString():((int)pl.second).ToString());
            SavePanel.transform.GetChild(0).transform.GetChild(4).GetComponent<Text>().text = "所持金　" + pl.money.ToString() + "円";
        }
        else
        {
            IsnullF = true;
            SavePanel.transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
            SavePanel.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
            SavePanel.transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(false);
            SavePanel.transform.GetChild(0).transform.GetChild(5).gameObject.SetActive(true);
        }
    }
    //読み込むファイル選択
    public void SelectFile(int num)
    {
        SaveFNum += num;
        if(type == SLType.Save)
        {
            if (SaveFNum < 1) SaveFNum = 5;
        }
        else
        {
            if (SaveFNum < 0) SaveFNum = 5;
        }
        if(SaveFNum > 5)
        {
            if (type == SLType.Save)
            {
                SaveFNum = 1;
            }
            else
            {
                SaveFNum = 0;
            }
        }
        SaveDataDisplay(SaveFNum);
    }
    //決定ボタンに値するボタン選択時
    public void Submit()
    { 
        switch (pos)
        {
            case NowPosition.Arart:
                Save(SaveFNum);
                break;
            case NowPosition.SelectFile:
                if (!IsnullF)
                {
                    ArartPanel.SetActive(true);
                    pos = NowPosition.Arart;
                }
                else Save(SaveFNum);
                break;
            default:
                break;
        }
    }
    //各種キャンセルボタンを押したとき
    public void Cancel()
    {
        switch (pos)
        {
            case NowPosition.Arart:
                ArartPanel.SetActive(false);
                pos = NowPosition.SelectFile;
                break;
            default:
                DonePanel.SetActive(false);
                ArartPanel.SetActive(false);
                SavePanel.SetActive(false);
                pos = NowPosition.None;
                break;
        }
    }
    //セーブ
    public void Save(int SaveNum)
    {
        PlData = GetComponent<PlayerData>();
        TimeCounter tc = GetComponent<TimeCounter>();
        SaveData sd = new SaveData();
        string json = "";
        if (SaveNum != -1)
        {
            sd.money = PlData.money;
            sd.days = tc.GetTime().day;
            sd.hour = tc.GetTime().hour;
            sd.second = tc.GetTime().second;
            sd.itemvalues = GetComponent<ItemManager>().GetSaveItem();
            sd.plantN = GetComponent<Planter>().GetPlantN();
            sd.plantG = GetComponent<Planter>().GetPlantG();
            json = JsonUtility.ToJson(sd);
        }
        else json = JsonUtility.ToJson(GetComponent<Option>().GetConfigData());
        File.WriteAllText(GetFileName(SaveNum),json);
        if(type == SLType.Save)DonePanel.SetActive(true);
        pos = NowPosition.Done;
        
    }
    //ロード
    public SaveData Load(int SaveNum)
    {
        try
        {
            if (SaveNum == -1) return null;
            string json = File.ReadAllText(GetFileName(SaveNum));
            SaveData sd =  JsonUtility.FromJson<SaveData>(json);
            return sd;
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            return null;
        }
    }
    //コンフィグのロード
    public Option.ConfigData CLoad()
    {
        try
        {
            string json = File.ReadAllText(GetFileName(-1));
            Option.ConfigData cd = JsonUtility.FromJson<Option.ConfigData>(json);
            return cd;
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            return null;
        }
    }
    //ロードボタンを押したとき
    public void SelectLoad()
    {
        if (IsnullF)
        {
            return;
        }
        SceneChange sc = GameObject.Find("SceneChenger").GetComponent<SceneChange>();
        Debug.Log(Load(SaveFNum).itemvalues);
        sc.SetSaveData(Load(SaveFNum));
        sc.SendScene("MainGame");
    }
    string GetFileName(int SaveNum)
    {
        if (!Directory.Exists(savefile)) Directory.CreateDirectory(savefile);
        switch (SaveNum)
        {
            case -1:
                return savefile + "\\" + filepu;
            case 0:
                return savefile + "\\" + file00;
            case 1:
                return savefile + "\\" + file01;
            case 2:
                return savefile + "\\" + file02;
            case 3:
                return savefile + "\\" + file03;
            case 4:
                return savefile + "\\" + file04;
            case 5:
                return savefile + "\\" + file05;
            default:
                return null;
        }
    }
    
    public class SaveData
    {
        [SerializeField] public int money;
        [SerializeField] public int days = 0;
        [SerializeField] public int hour = 7;
        [SerializeField] public float second = 0;
        [SerializeField] public string itemvalues;
        [SerializeField] public string plantN;
        [SerializeField] public string plantG;
        public SaveData()
        {
            string str = "";
            List<int> it = new List<int>();
            ItemData[] ia = Resources.LoadAll<ItemData>("Seed");
            for (int i = 0; i < ia.Length; i++)
            {
                str += "0,";
            }
            ia = Resources.LoadAll<ItemData>("Plant");
            for (int i = 0; i < ia.Length; i++)
            {
                str += "0,";
            }
            str.TrimEnd(',');
            itemvalues = str;
            Debug.Log(itemvalues);
            string sg = "";
            for (int i = 0;i < 16; i++)
            {
                str += "空,";
                sg += "0,";
            }
            str.TrimEnd(',');
            sg.TrimEnd(',');
            plantN = str;
            plantG = sg;
        }
    }
    public SaveData GetSaveData()
    {
        return save;
    }
    public void SetSaveData(SaveData sd)
    {
        save = sd;
    }
}
