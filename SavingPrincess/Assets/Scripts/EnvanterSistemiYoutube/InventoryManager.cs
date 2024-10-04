
//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class InventoryManager : MonoBehaviour
//{
//    public GameObject InventoryMenu; // Envanter paneli
//    public GameObject StorePanel; // Dükkan paneli
//    public bool menuActivated;

//    public PlayerController playerMovement;

//    public ItemSlot[] itemSlot; // Dizinin private olmasýný saðlamak

//    public GameObject eatButton; // "Yemeði Ye" butonu
//    public GameObject dropButton; // "Ýtemi Dýþarý At" butonu

//    void Start()
//    {
//        // Baþlangýçta envanter kapalý
//        InventoryMenu.SetActive(false);
//        menuActivated = false;
//        // Butonlarý gizle
//        eatButton.SetActive(false);
//        dropButton.SetActive(false);
//    }

//    void Update()
//    {
//        // Tab tuþuna basýldýðýnda envanter aç/kapat iþlemi yapýlýyor, ama dükkan paneli açýk deðilse
//        if (Input.GetKeyDown(KeyCode.Tab) && !StorePanel.activeSelf)
//        {
//            if (menuActivated)
//            {
//                // Envanter kapatýldýðýnda tüm itemleri seçimi temizle
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
//        // Ayný item var mý kontrol et
//        for (int i = 0; i < itemSlot.Length; i++)
//        {
//            if (itemSlot[i].isFull && itemSlot[i].itemName == itemName)
//            {
//                // Ayný isimde item varsa, miktarýný artýr
//                itemSlot[i].AddQuantity(quantity);
//                return;
//            }
//        }

//        // Eðer ayný item yoksa, boþ bir slot bul ve doldur
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
//            itemSlot[i].ResetItemSelection(); // Item slotlarýnýn seçimini sýfýrla
//        }

//        // Butonlarý gizle
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
    public GameObject StorePanel; // Dükkan paneli
    public bool menuActivated;

    public PlayerController playerMovement;

    public ItemSlot[] itemSlot; // Envanter slotlarý

    public GameObject eatButton; // "Yemeði Ye" butonu
    public GameObject dropButton; // "Ýtemi Dýþarý At" butonu
    public Button useButton; // "Item Kullan" butonu

    public Slider healthSlider; // Can barý slider
    private List<Item> allItems; // Tüm itemleri saklamak için liste

    void Start()
    {
        InventoryMenu.SetActive(false);
        menuActivated = false;
        eatButton.SetActive(false);
        dropButton.SetActive(false);

        useButton.onClick.AddListener(UseSelectedItem);

        if (itemSlot == null || itemSlot.Length == 0)
        {
            Debug.LogError("Item slotlarý atanmadý veya boþ.");
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

        Debug.LogWarning("Tüm slotlar dolu, item eklenemedi.");
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
        // Burada item ile ilgili yapmanýz gereken iþlemleri belirtebilirsiniz
        Debug.Log("Item Actions shown for: " + itemName);
        // Örneðin, yemeði ye ve eþyayý at butonlarýný gösterebilirsiniz
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
                    Debug.Log($"Can artýrýldý: {healthAmount} - Yeni Can: {healthSlider.value}");
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
