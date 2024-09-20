using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public void AddItem(InventoryItem newItem)
    {
        // Ayn� t�rde bir e�ya zaten varsa, miktar�n� art�r
        foreach (InventoryItem item in items)
        {
            if (item.itemName == newItem.itemName)
            {
                item.amount += newItem.amount;
                return;
            }
        }
        // Yeni ��e ekle
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