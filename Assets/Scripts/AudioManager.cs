using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] BGM;
    public AudioClip[] SE;
    [SerializeField] AudioSource[] audioSource;
    private void Update()
    {
        //TestSE();
    }
    //bgm再生
    public void PlayBgm(int num)
    {
        audioSource[0].clip = BGM[num];
        audioSource[0].Play();
    }
    public void PlayBgm(AudioClip ac)
    {
        audioSource[0].clip = ac;
        audioSource[0].Play();
    }
    //bgm停止
    public void StopBGM()
    {
        audioSource[0].Stop();
    }
    //se再生
    public void PlaySE(int num)
    {
        audioSource[1].PlayOneShot(SE[num]);
    }
    //se再生
    public void PlaySE(AudioClip ac)
    {
        audioSource[1].PlayOneShot(ac);
    }
    //se再生(中断するもの)
    public void PlaySE2(int num)
    {
        audioSource[1].clip = SE[num];
        audioSource[1].Play();
    }
    //se停止
    public void StopSE2()
    {
        audioSource[1].Stop();
    }
}
