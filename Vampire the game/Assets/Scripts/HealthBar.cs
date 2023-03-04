using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sprite[] hp = new Sprite[11];
    [SerializeField] private Image healthImage;
    [SerializeField] private TextMeshProUGUI healthText;
    private PlayerHealth playerHealth;
    private int maxHealth;
    private int currentHealth;
    private int hp10;

    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        
    }

    void Start()
    {
        maxHealth = playerHealth.getMaxHp();
        currentHealth = playerHealth.getCurrentHp();
        hp10 = maxHealth / 10;
        healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    void Update()
    {
        currentHealth = playerHealth.getCurrentHp();
        setHealth(currentHealth);
        healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
    public void setHealth(int currentHealth)
    {
        if (currentHealth == maxHealth)
            healthImage.sprite = hp[10];
        else if (currentHealth < maxHealth && currentHealth >= (9 * hp10))
            healthImage.sprite = hp[9];
        else if (currentHealth < (9 * hp10) && currentHealth >= (8 * hp10))
            healthImage.sprite = hp[8];
        else if (currentHealth < (8 * hp10) && currentHealth >= (7 * hp10))
            healthImage.sprite = hp[7];
        else if (currentHealth < (7 * hp10) && currentHealth >= (6 * hp10))
            healthImage.sprite = hp[6];
        else if (currentHealth < (6 * hp10) && currentHealth >= (5 * hp10))
            healthImage.sprite = hp[5];
        else if (currentHealth < (5 * hp10) && currentHealth >= (4 * hp10))
            healthImage.sprite = hp[4];
        else if (currentHealth < (4 * hp10) && currentHealth >= (3 * hp10))
            healthImage.sprite = hp[3];
        else if (currentHealth < (3 * hp10) && currentHealth >= (2 * hp10))
            healthImage.sprite = hp[2];
        else if (currentHealth < (2 * hp10) && currentHealth >= (1 * hp10))
            healthImage.sprite = hp[1];
        else if (currentHealth < (1 * hp10))
            healthImage.sprite = hp[0];
    }

}