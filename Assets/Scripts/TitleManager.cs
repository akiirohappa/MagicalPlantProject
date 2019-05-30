using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject Option;
    AudioManager am;
    private void Awake()
    {
        am = GameObject.Find("SceneChenger").GetComponent<AudioManager>();
        am.PlayBgm(am.BGM[0]);
        
    }
    private void Start()
    {
        GetComponent<Option>().SetConfigData();
    }
    public void NewGame()
    {
        am.PlaySE(am.SE[0]);
        SceneChange sc = GameObject.Find("SceneChenger").GetComponent<SceneChange>();
        sc.SetSaveData(new SaveLoad.SaveData());
        sc.SendScene("MainGame");
    }
    public void OpenConfig()
    {
        am.PlaySE(am.SE[0]);
        Option.SetActive(true);
        GetComponent<Option>().OpenMenu();
    }
    public void CloseConfig()
    {
        am.PlaySE(am.SE[1]);
        Option.SetActive(false);
    }
}
