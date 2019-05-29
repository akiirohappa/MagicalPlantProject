using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Option : MonoBehaviour
{
    [SerializeField]ConfigData Cd;
    SaveLoad Sv;
    [SerializeField]AudioMixer audioMixer;
    [SerializeField] Slider Bgmsl;
    [SerializeField] Slider Sesl;
    // Start is called before the first frame update
    void Awake()
    {
        Sv = GetComponent<SaveLoad>();
        Cd = Sv.CLoad();
        if (Cd == null) Cd = new ConfigData();
    }
    public void OpenMenu()
    {
        SetConfigData();
    }
    void CloseMenu()
    {

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
        Sv.Save(-1);
    }
    public ConfigData GetConfigData()
    {
        return Cd;
    }
    public void SetConfigData()
    {
        Cd = Sv.CLoad();
        SetVolume();
        Bgmsl.value = Cd.BGMvol;
        Sesl.value = Cd.SEvol;
    }
}
