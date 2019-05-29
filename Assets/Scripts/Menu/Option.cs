using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Option : MonoBehaviour
{
    ConfigData Cd;
    [SerializeField]AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        Cd = GetComponent<ConfigData>();
    }
    public void ChangeVolBGM(float vol)
    {
        Cd.BGMvol = vol;
        SetVolume();
    }
    public void ChangeVolSE(float vol)
    {
        Cd.SEvol = vol;
        SetVolume();
    }
    void SetVolume()
    {
        audioMixer.SetFloat("BGMVol", Cd.BGMvol);
        audioMixer.SetFloat("SEVol", Cd.SEvol);
    }
    public ConfigData GetConfigData()
    {
        return Cd;
    }
    public void SetConfigData(ConfigData c)
    {
        Cd = c;
    }
}
