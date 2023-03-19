using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeManager : MonoBehaviour, ISaveable 
{
    // Start is called before the first frame update
    [SerializeField]
    public TextMeshProUGUI timeText;
    [SerializeField] private int damage;

    [SerializeField] public int time;

    //public bool nightTime = truea;
    public static int Minute, Hour;

    private float minuteToRealTime = 0.5f;
    private float timer;
    private PlayerHealth ph;
    
    void Start()
    {
        Minute = time%60;
        Hour = time/60;
        timer = minuteToRealTime;
        ph = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        //CheckTime();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (time>0) 
            {
                time--;
                /*if (time%60 == 0)
                {
                    CheckTime();
                }*/
                
            }
            if(time<=0)
            {
                if (ph.getCurrentHp() > 0)
                {
                    ph.takeDamage(damage);
                }
            }
            timer = minuteToRealTime;
        }
        Minute = time % 60;
        Hour = time / 60;
        timeText.text = $"{TimeManager.Hour:00}:{TimeManager.Minute:00}";
    }
    /*private void CheckTime()
    {
        if (Hour <= 0 && Minute <=0)
        {
            nightTime = false;
        }
        else
        {
            nightTime = true;
        }
    }*/
    public object SaveState()
    {
        return new SaveData()
        {
            time=time
        };
    }
    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        time = saveData.time;
    }
    [Serializable]
    private struct SaveData
    {
        public int time;
    }
}
