using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]


public class InventoryItem
{
    public string itemName;
    public string description;
    public Sprite icon;
    public ItemType itemType; // ��e tipi (silah, z�rh, yiyecek vb.)
    public int amount; // Miktar

    public enum ItemType
    {
        Weapon,
        Armor,
        Food,
        Other
    }
}