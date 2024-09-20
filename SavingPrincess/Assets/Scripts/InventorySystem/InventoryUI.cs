using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public InventorySlot[] slots;
    public GameObject itemButtonPrefab; // Buton prefab'� (her ��e i�in kullan�lacak)
    public Transform itemsParent; // Grid Layout Group'un oldu�u Transform
    public void UpdateUI(List<InventoryItem> items)
    {
        // T�m slotlar� temizle
        foreach (InventorySlot slot in slots)
        {
            slot.ClearSlot();
        }

        // Slotlara item ekle
        for (int i = 0; i < items.Count; i++)
        {
            slots[i].AddItem(items[i]);
        }
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    public void AddItemToInventory(InventoryItem item)
    {
        GameObject button = Instantiate(itemButtonPrefab, itemsParent); // Buton olu�tur
        button.GetComponentInChildren<Text>().text = item.itemName; // Butonun ad�n� ayarla
        button.GetComponent<Image>().sprite = item.icon; // Butonun ikonu
    }
}