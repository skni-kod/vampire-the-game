using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public coins coins;

    
    public GameObject ShopUI;

    private void Start()
    {
        
    }
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
}
