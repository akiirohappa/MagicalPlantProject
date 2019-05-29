//-----------------------------------
//時間進行の管理
//-----------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TimeMode
{
    Noon,
    Night
}
public class TimeCounter : MonoBehaviour
{
    Planter Pl;
    public Light DayLight;
    [SerializeField] int day;
    [SerializeField] int hour;
    [SerializeField] float second;
    [SerializeField] Text DayText;
    [SerializeField] Text Timetext;
    [SerializeField] TimeMode time = TimeMode.Noon;
    public int changetime = 1;
    public int accsel = 1;
    // Start is called before the first frame update
    void Start()
    {
        Pl = GetComponent<Planter>();
        day = 1;
        DayText.text = day + "日目";
        hour = 7;
        second = 00f;
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime*accsel;
        TimeShow();
        if (second >= 60f)
        {
            hour++;
            second = 0f;
            Pl.Growth();
        }
        if (hour >= 24)
        {
            hour = 0;
        }
        if (hour >= 19 && time == TimeMode.Noon)
        {
            StartCoroutine(LightChange(time));
            time = TimeMode.Night;
        }
        if (hour >= 7 && hour < 19&& time == TimeMode.Night)
        {
            StartCoroutine(LightChange(time));
            time = TimeMode.Noon;
            day++;
            DayText.text = day + "日目";
        }
    }
    public IEnumerator LightChange(TimeMode t)
    {
        for(int i = 0;i < changetime; i++)
        {
            if (t == TimeMode.Noon)
            {
                float cl = 1f - ((1f / changetime) * i);
                DayLight.color = new Color(cl, cl, cl);
            }
            else
            {
                float cl = ((1f / changetime) * i);
                DayLight.color = new Color(cl, cl, cl);
                //Debug.Log(cl);
            }
            //yield return new WaitForSeconds(0.5f);
            yield return null;
        }
    }
    void TimeShow()
    {
        string sc;
        if(second < 10)sc = "0" + ((int)second).ToString();
        else sc = ((int)second).ToString();
        Timetext.text = hour.ToString() + " : " + sc;
    }
    public class TimeData
    {
        public int day;
        public int hour;
        public float second;
        public TimeData(int d,int h,float s)
        {
            day = d;
            hour = h;
            second = s;
        }
    }
    public TimeData GetTime()
    {
        return new TimeData(day, hour, second);
    }
    public void SetTime(int d, int h, float s)
    {
        day = d;
        hour = h;
        second = s;
    }
}
