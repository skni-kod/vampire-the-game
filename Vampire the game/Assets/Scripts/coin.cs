using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coin : MonoBehaviour, ISaveable
{
    public static int points = 0;
    public TextMeshProUGUI pointsText;
    

    void Update()
    {
        pointsText.text = points.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
        
    {
        if(collision.tag=="Coin")
        {
            points++;
            

            Destroy(collision.gameObject);

        }
    }
    public object SaveState()
    {
        return new SaveData()
        {
            points = coin.points
        };
    }
    public void LoadState(object state) 
    {
        var saveData = (SaveData)state;
        points = saveData.points;
    }
    [System.Serializable]
    private struct SaveData
    {
        public int points;
    }
}

