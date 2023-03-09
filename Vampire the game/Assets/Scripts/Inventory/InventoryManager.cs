using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Slot slotPrefab;
    private RectTransform inventoryContent;
    private static int inventorySlots = 3;

    void Awake()
    {
        inventoryContent = GetComponent<RectTransform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < inventorySlots; i++)
        {
            Slot UISlot = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity);
            UISlot.transform.SetParent(inventoryContent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlots();
    }

    private void UpdateSlots()
    {
        for(int i = 0; i < inventorySlots; i++)
        {
            if(i < ItemsDataBase.Instance.playerItems.Count)
            {
                inventoryContent.transform.GetChild(i).Find("Icon").gameObject.SetActive(true);
                inventoryContent.transform.GetChild(i).Find("Icon").GetComponent<Image>().sprite = ItemsDataBase.Instance.playerItems[i].Icon;
            }
            else
            {
                inventoryContent.transform.GetChild(i).Find("Icon").gameObject.SetActive(false);
                inventoryContent.transform.GetChild(i).Find("Icon").GetComponent<Image>().sprite = null;
            }
            
        }
    }

    public void AddItem(int ID)
    {
        if(ItemsDataBase.Instance.playerItems.Count < inventorySlots)
        {
            ItemsDataBase.Instance.playerItems.Add(ItemsDataBase.Instance.items[ID]);
        }
    }

    public static int GetInventorySlots()
    {
        return inventorySlots;
    }
}
