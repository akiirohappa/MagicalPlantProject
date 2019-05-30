using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject Option;

    public void NewGame()
    {
        SceneChange sc = GameObject.Find("SceneChenger").GetComponent<SceneChange>();
        sc.SetSaveData(new SaveLoad.SaveData());
        sc.SendScene("MainGame");
    }
    public void OpenConfig()
    {
        Option.SetActive(true);
        GetComponent<Option>().OpenMenu();
    }
    public void CloseConfig()
    {
        Option.SetActive(false);
    }
}
