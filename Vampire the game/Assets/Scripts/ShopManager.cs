using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public int coins;
    public Text coinText;
    public Text cashText;
    public Upgraded[] upgrades;
    
    public GameObject ShopUI;
    public Transform ShopContent;
    public GameObject itemPrefab;
    public PlayerMovement player;
    public PlayerHealth health;


   
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
    private void Start()
    {
        foreach (Upgraded upgraded in upgrades )
        {
            GameObject item = Instantiate(itemPrefab, ShopContent);

            upgraded.itemRef = item;

            foreach (Transform child in  item.transform)
            {
               
                if (child.gameObject.name == "Cost")
                {
                    child.gameObject.GetComponent<Text>().text ="$" + upgraded.cost.ToString();

                }
                else if (child.gameObject.name == "Name")
                {
                    child.gameObject.GetComponent<Text>().text =  upgraded.name;
                }
                else if (child.gameObject.name == "Image")
                {
                    child.gameObject.GetComponent<Image>().sprite = upgraded.image;
                }

            }
            item.GetComponent<Button>().onClick.AddListener(() => { BuyUpgraded(upgraded); });
        }
       
      
    }
    private void BuyUpgraded(Upgraded upgraded)
    {
        if (coins >= upgraded.cost)
        {
            upgraded.quantity++;
           
            if(1 != upgraded.quantity)
            {
                
            }
            else
            {
                coins -= upgraded.cost;
                upgraded.itemRef.transform.GetChild(0).GetComponent<Text>().text ="Upgraded" + upgraded.ToString();
            }
            
            
        }
        ApplyUpgrade(upgraded);
    }
    public void ApplyUpgrade(Upgraded upgraded)
    {
        switch (upgraded.name)
        {
            case "hp":
                {
                    health.maxHp += 20;
                    break;
                }
            case "speed":
                {
                    player.moveSpeed += 5f;
                    break;
                }

        }
    }

public void ToggleShop()
    {
        ShopUI.SetActive(!ShopUI.activeSelf);
    }
    private void OnGUI()
    {
        coinText.text = "Coins: " + coins.ToString();
        cashText.text =  coins.ToString();
    }
}
[System.Serializable]
public class Upgraded
{
    public string name;
    public int cost;
    public Sprite image;
    [HideInInspector] public int quantity;
    [HideInInspector] public GameObject itemRef;
}
