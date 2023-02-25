using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public int coins;
    public Text coinText;
    public Upgrade[] upgrades;
    
    public GameObject ShopUI;

   
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void ToggleShop()
    {
        ShopUI.SetActive(!ShopUI.activeSelf);
    }
    private void OnGUI()
    {
        coinText.text = "Coins: " + coins.ToString();
    }
}
[System.Serializable]
public class Upgrade
{
    public string name;
    public int cost;
    public Sprite image;
}
