//----------------------------------------------------------
//シーン移動およびシーン間の情報受け渡し
//----------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    static public SceneChange inst;
    [SerializeField] SaveLoad.SaveData sd;

    void Awake()
    {
        if (inst == null)
        {
            inst = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(gameObject);
    }
    public void SendScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void SetSaveData(SaveLoad.SaveData s)
    {
        sd = s;
    }
    public SaveLoad.SaveData GetSaveData()
    {
        return sd;
    }
}
