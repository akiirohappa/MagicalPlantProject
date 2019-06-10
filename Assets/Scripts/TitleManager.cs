//----------------------------------------------------
//タイトル画面の管理
//----------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject Option;
    AudioManager am;
    //BGM再生
    private void Awake()
    {
        am = GameObject.Find("SceneChenger").GetComponent<AudioManager>();
        am.PlayBgm(am.BGM[0]);
    }
    //コンフィグデータの参照
    private void Start()
    {
        GetComponent<Option>().SetConfigData();
    }
    //ニューゲームを押したとき
    public void NewGame()
    {
        am.PlaySE(am.SE[0]);
        SceneChange sc = GameObject.Find("SceneChenger").GetComponent<SceneChange>();
        sc.SetSaveData(new SaveLoad.SaveData());
        sc.SendScene("MainGame");
    }
    //コンフィグ画面展開
    public void OpenConfig()
    {
        am.PlaySE(am.SE[0]);
        Option.SetActive(true);
        GetComponent<Option>().OpenMenu();
    }
    //コンフィグ画面閉じる
    public void CloseConfig()
    {
        am.PlaySE(am.SE[1]);
        Option.SetActive(false);
    }
    //ゲーム終了
    public void QueitGame()
    {
        Application.Quit();
    }
}
