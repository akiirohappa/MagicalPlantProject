//----------------------------------------------------------
//シーン移動およびシーン間の情報受け渡し
//----------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    static public SceneChange inst;
    [SerializeField] SaveLoad.SaveData sd;
    AsyncOperation async;
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject paPref;
    [SerializeField]GameObject Panel;
    [SerializeField] GameObject Icon;
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
        StartCoroutine(LoadScene(sceneName));
        //SceneManager.LoadScene(sceneName);
    }
    IEnumerator LoadScene(string scene)
    {
        Canvas = GameObject.Find("Canvas");
        Panel = Instantiate(paPref, Canvas.transform);
        Icon = Panel.transform.GetChild(1).gameObject;
        Panel.SetActive(true);
        async = SceneManager.LoadSceneAsync(scene);
        float rot = 0;
        while (!async.isDone)
        {
            rot += 0.5f;
            Icon.transform.Rotate(new Vector3(Icon.transform.rotation.x, Icon.transform.rotation.y, rot));
            yield return null;
        }
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
