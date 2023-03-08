using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDataBase : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<Item> playerItems = new List<Item>();
    public static ItemsDataBase Instance;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

}

[System.Serializable]
public class Item
{
    public enum ItemType
    {
        Key, Weapon, Potion
    }

    public string Name;
    public string Description;
    public int ID;
    public ItemType Type;
    public Sprite Icon;

    public Item(string name, string description, int iD, ItemType type, Sprite icon)
    {
        Name = name;
        Description = description;
        ID = iD;
        Type = type;
        Icon = icon;
    }
}
