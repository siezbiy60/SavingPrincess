using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public void AddItem(InventoryItem newItem)
    {
        // Ayný türde bir eþya zaten varsa, miktarýný artýr
        foreach (InventoryItem item in items)
        {
            if (item.itemName == newItem.itemName)
            {
                item.amount += newItem.amount;
                return;
            }
        }
        // Yeni öðe ekle
        items.Add(newItem);
    }

    public void RemoveItem(InventoryItem itemToRemove)
    {
        if (items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
        }
    }
}