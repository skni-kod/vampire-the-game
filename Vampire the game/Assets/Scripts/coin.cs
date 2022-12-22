using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class coin : MonoBehaviour, ISaveable
{
    public int points = 0;
    public TextMeshProUGUI pointsText;
    public Animator animator;

    void Update()
    {
        pointsText.text = points.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Coin")
        {
            points++;


            Destroy(collision.gameObject);

        }
        
    }
    
    public object SaveState()
    {
        return new SaveData()
        {
            points = this.points
        };
    }
    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        points = saveData.points;
    }
    [Serializable]
    private struct SaveData
    {
        public int points;
    }
}

