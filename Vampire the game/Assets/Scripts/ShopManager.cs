using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public int coins;
    public Text coinText;
    public Upgrade[] upgrades;
    
    public GameObject ShopUI;
    public Transform ShopContent;
    public GameObject itemPrefab;
    public PlayerMovement player;


   
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
        foreach (Upgrade upgrade in upgrades )
        {
            GameObject item = Instantiate(itemPrefab, ShopContent);

            upgrade.itemRef = item;

            foreach (Transform child in  item.transform)
            {
                if(child.gameObject.name == "Quantity")
                {
                    child.gameObject.GetComponent<Text>().text = upgrade.ToString();
                   
                }
                else if (child.gameObject.name == "Cost")
                {
                    child.gameObject.GetComponent<Text>().text = "$" + upgrade.cost.ToString();

                }
                else if (child.gameObject.name == "Name")
                {
                    child.gameObject.GetComponent<Text>().text = "$" + upgrade.name;
                }
                else if (child.gameObject.name == "Image")
                {
                    child.gameObject.GetComponent<Image>().sprite = upgrade.image;
                }

            }
            item.GetComponent<Button>().onClick.AddListener(() => { });
        }
       
      
    }
    private void BuyUpgrade(Upgrade upgrade)
    {
        if (coins >= upgrade.cost)
        {
            coins -= upgrade.cost;
            upgrade.quantity++;
            upgrade.itemRef.transform.GetChild(0).GetComponent<Text>().text = upgrade.quantity.ToString();
        }
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
    [HideInInspector] public int quantity;
    [HideInInspector] public GameObject itemRef;
}
