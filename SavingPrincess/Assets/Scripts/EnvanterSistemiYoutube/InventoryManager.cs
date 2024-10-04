
//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class InventoryManager : MonoBehaviour
//{
//    public GameObject InventoryMenu; // Envanter paneli
//    public GameObject StorePanel; // D�kkan paneli
//    public bool menuActivated;

//    public PlayerController playerMovement;

//    public ItemSlot[] itemSlot; // Dizinin private olmas�n� sa�lamak

//    public GameObject eatButton; // "Yeme�i Ye" butonu
//    public GameObject dropButton; // "�temi D��ar� At" butonu

//    void Start()
//    {
//        // Ba�lang��ta envanter kapal�
//        InventoryMenu.SetActive(false);
//        menuActivated = false;
//        // Butonlar� gizle
//        eatButton.SetActive(false);
//        dropButton.SetActive(false);
//    }

//    void Update()
//    {
//        // Tab tu�una bas�ld���nda envanter a�/kapat i�lemi yap�l�yor, ama d�kkan paneli a��k de�ilse
//        if (Input.GetKeyDown(KeyCode.Tab) && !StorePanel.activeSelf)
//        {
//            if (menuActivated)
//            {
//                // Envanter kapat�ld���nda t�m itemleri se�imi temizle
//                DeselectAllSlots();
//                InventoryMenu.SetActive(false);
//                menuActivated = false;
//                playerMovement.EnableMovement();  // Karakter hareketini durdur
//            }
//            else
//            {
//                InventoryMenu.SetActive(true);
//                menuActivated = true;
//                playerMovement.DisableMovement();  // Karakter hareketini durdur
//            }
//        }
//    }

//    // Item ekleme fonksiyonu
//    public void AddItem(string itemName, int quantity, Sprite sprite, string itemDescription)
//    {
//        // Ayn� item var m� kontrol et
//        for (int i = 0; i < itemSlot.Length; i++)
//        {
//            if (itemSlot[i].isFull && itemSlot[i].itemName == itemName)
//            {
//                // Ayn� isimde item varsa, miktar�n� art�r
//                itemSlot[i].AddQuantity(quantity);
//                return;
//            }
//        }

//        // E�er ayn� item yoksa, bo� bir slot bul ve doldur
//        for (int i = 0; i < itemSlot.Length; i++)
//        {
//            if (!itemSlot[i].isFull)
//            {
//                itemSlot[i].AddItem(itemName, quantity, sprite, itemDescription);
//                return;
//            }
//        }
//    }

//    public void DeselectAllSlots()
//    {
//        for (int i = 0; i < itemSlot.Length; i++)
//        {
//            itemSlot[i].ResetItemSelection(); // Item slotlar�n�n se�imini s�f�rla
//        }

//        // Butonlar� gizle
//        eatButton.SetActive(false);
//        dropButton.SetActive(false);
//    }

//    public void ShowItemActions(string itemName)
//    {
//        Debug.Log("Selected Item: " + itemName);

//        if (itemName == "food")
//        {
//            eatButton.SetActive(true);
//            dropButton.SetActive(true);
//        }
//        else
//        {
//            eatButton.SetActive(false);
//            dropButton.SetActive(false);
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu; // Envanter paneli
    public GameObject StorePanel; // D�kkan paneli
    public bool menuActivated;

    public PlayerController playerMovement;

    public ItemSlot[] itemSlot; // Envanter slotlar�

    public GameObject eatButton; // "Yeme�i Ye" butonu
    public GameObject dropButton; // "�temi D��ar� At" butonu
    public Button useButton; // "Item Kullan" butonu

    public Slider healthSlider; // Can bar� slider
    private List<Item> allItems; // T�m itemleri saklamak i�in liste

    void Start()
    {
        InventoryMenu.SetActive(false);
        menuActivated = false;
        eatButton.SetActive(false);
        dropButton.SetActive(false);

        useButton.onClick.AddListener(UseSelectedItem);

        if (itemSlot == null || itemSlot.Length == 0)
        {
            Debug.LogError("Item slotlar� atanmad� veya bo�.");
            itemSlot = GetComponentsInChildren<ItemSlot>();
        }

        GetAllItems();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !StorePanel.activeSelf)
        {
            if (menuActivated)
            {
                DeselectAllSlots();
                InventoryMenu.SetActive(false);
                menuActivated = false;
                playerMovement.EnableMovement();

                eatButton.SetActive(false);
                dropButton.SetActive(false);
            }
            else
            {
                InventoryMenu.SetActive(true);
                menuActivated = true;
                playerMovement.DisableMovement();

                eatButton.SetActive(true);
                dropButton.SetActive(true);
            }
        }
    }

    private void GetAllItems()
    {
        allItems = new List<Item>(FindObjectsOfType<Item>());
    }

    public void AddItem(string itemName, int quantity, Sprite sprite, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull && itemSlot[i].itemName == itemName)
            {
                itemSlot[i].AddQuantity(quantity);
                return;
            }
        }

        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isFull)
            {
                itemSlot[i].AddItem(itemName, quantity, sprite, itemDescription);
                return;
            }
        }

        Debug.LogWarning("T�m slotlar dolu, item eklenemedi.");
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].ResetItemSelection();
        }

        eatButton.SetActive(false);
        dropButton.SetActive(false);
    }

    public void ShowItemActions(string itemName)
    {
        // Burada item ile ilgili yapman�z gereken i�lemleri belirtebilirsiniz
        Debug.Log("Item Actions shown for: " + itemName);
        // �rne�in, yeme�i ye ve e�yay� at butonlar�n� g�sterebilirsiniz
        eatButton.SetActive(true);
        dropButton.SetActive(true);
    }

    public void UseSelectedItem()
    {
        foreach (var slot in itemSlot)
        {
            if (slot.thisItemSelected && slot.quantity > 0)
            {
                int healthAmount = 0;

                if (slot.itemName == "HealthPotion")
                {
                    healthAmount = 20;
                }
                else if (slot.itemName == "food")
                {
                    healthAmount = 10;
                }

                if (healthAmount > 0)
                {
                    healthSlider.value = Mathf.Min(healthSlider.maxValue, healthSlider.value + healthAmount);
                    Debug.Log($"Can art�r�ld�: {healthAmount} - Yeni Can: {healthSlider.value}");
                }

                slot.UseItem();
                break;
            }
        }
    }

    public void RemoveItemFromSlot(ItemSlot slot)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i] == slot)
            {
                itemSlot[i].ClearSlot();
                return;
            }
        }
    }
}
