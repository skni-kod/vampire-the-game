using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeManager : MonoBehaviour, ISaveable
{
    //public static Action OnMinuteChanged;
    //public static Action OnHourChanged;

    [SerializeField]
    public TextMeshProUGUI timeText;

    public static int Minute;
    public static int Hour;

    private float minuteToRealTime = 0.5f;
    private float timer;
    void Start()
    {
        Minute = 0;
        Hour = 0;
        timer = minuteToRealTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Minute++;
            if (Minute >= 60)
            {
                Hour++;
                if(Hour >= 24)
                {
                    Hour = 0;
                }
                Minute = 0;
            }
            timer = minuteToRealTime;
        }
        timeText.text = $"{TimeManager.Hour:00}:{TimeManager.Minute:00}";
    }
    public object SaveState() 
    {
        return new SaveData()
        {
            Minute = Minute,
            Hour = Hour
        };
    }
    public void LoadState(object state) 
    {
        var saveData = (SaveData)state;
        Debug.Log(saveData.Minute.ToString()+ saveData.Hour.ToString());
        Minute = saveData.Minute;
        Hour = saveData.Hour;
    }
    [Serializable]
    private struct SaveData 
    {
        public int Minute;
        public int Hour;
    }
}
