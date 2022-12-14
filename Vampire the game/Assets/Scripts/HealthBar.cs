using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sprite[] hp = new Sprite[11];
    private Image image;
    private int maxHealth;
    private int hp10;
    
    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void setMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        hp10 = maxHealth / 10;
    }
    public void setHealth(int currentHealth)
    {
        if (currentHealth == maxHealth)
            this.gameObject.GetComponent<Image>().sprite = hp[10];
        else if (currentHealth < maxHealth && currentHealth >= (9 * hp10))
            this.gameObject.GetComponent<Image>().sprite = hp[9];
        else if (currentHealth < (9 * hp10) && currentHealth >= (8 * hp10))
            this.gameObject.GetComponent<Image>().sprite = hp[8];
        else if (currentHealth < (8 * hp10) && currentHealth >= (7 * hp10))
            this.gameObject.GetComponent<Image>().sprite = hp[7];
        else if (currentHealth < (7 * hp10) && currentHealth >= (6 * hp10))
            this.gameObject.GetComponent<Image>().sprite = hp[6];
        else if (currentHealth < (6 * hp10) && currentHealth >= (5 * hp10))
            this.gameObject.GetComponent<Image>().sprite = hp[5];
        else if (currentHealth < (5 * hp10) && currentHealth >= (4 * hp10))
            this.gameObject.GetComponent<Image>().sprite = hp[4];
        else if (currentHealth < (4 * hp10) && currentHealth >= (3 * hp10))
            this.gameObject.GetComponent<Image>().sprite = hp[3];
        else if (currentHealth < (3 * hp10) && currentHealth >= (2 * hp10))
            this.gameObject.GetComponent<Image>().sprite = hp[2];
        else if (currentHealth < (2 * hp10) && currentHealth >= (1 * hp10))
            this.gameObject.GetComponent<Image>().sprite = hp[1];
        else if (currentHealth < (1 * hp10))
            this.gameObject.GetComponent<Image>().sprite = hp[0];
    }
    
}
