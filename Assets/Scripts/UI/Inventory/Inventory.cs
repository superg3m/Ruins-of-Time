using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        Additem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        Debug.Log(itemList.Count);
    }
    public void Additem(Item item)
    {
        itemList.Add(item);
    }
}
