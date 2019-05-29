using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    [SerializeField] string SendSceneName;
    public void SendScene()
    {
        SceneManager.LoadScene(SendSceneName);
    }
}
