//using System;
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

//        // "food" itemini se�ti�inde butonlar� g�ster
//        if (itemName == "food")
//        {
//            eatButton.SetActive(true);
//            dropButton.SetActive(true);
//        }
//        else
//        {
//            // Di�er itemleri se�ti�inde butonlar� gizle
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

    public ItemSlot[] itemSlot; // Dizinin private olmas�n� sa�lamak

    public GameObject eatButton; // "Yeme�i Ye" butonu
    public GameObject dropButton; // "�temi D��ar� At" butonu

    void Start()
    {
        // Ba�lang��ta envanter kapal�
        InventoryMenu.SetActive(false);
        menuActivated = false;
        // Butonlar� gizle
        eatButton.SetActive(false);
        dropButton.SetActive(false);
    }

    void Update()
    {
        // Tab tu�una bas�ld���nda envanter a�/kapat i�lemi yap�l�yor, ama d�kkan paneli a��k de�ilse
        if (Input.GetKeyDown(KeyCode.Tab) && !StorePanel.activeSelf)
        {
            if (menuActivated)
            {
                // Envanter kapat�ld���nda t�m itemleri se�imi temizle
                DeselectAllSlots();
                InventoryMenu.SetActive(false);
                menuActivated = false;
                playerMovement.EnableMovement();  // Karakter hareketini durdur
            }
            else
            {
                InventoryMenu.SetActive(true);
                menuActivated = true;
                playerMovement.DisableMovement();  // Karakter hareketini durdur
            }
        }
    }

    // Item ekleme fonksiyonu
    public void AddItem(string itemName, int quantity, Sprite sprite, string itemDescription)
    {
        // Ayn� item var m� kontrol et
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull && itemSlot[i].itemName == itemName)
            {
                // Ayn� isimde item varsa, miktar�n� art�r
                itemSlot[i].AddQuantity(quantity);
                return;
            }
        }

        // E�er ayn� item yoksa, bo� bir slot bul ve doldur
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isFull)
            {
                itemSlot[i].AddItem(itemName, quantity, sprite, itemDescription);
                return;
            }
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].ResetItemSelection(); // Item slotlar�n�n se�imini s�f�rla
        }

        // Butonlar� gizle
        eatButton.SetActive(false);
        dropButton.SetActive(false);
    }

    public void ShowItemActions(string itemName)
    {
        Debug.Log("Selected Item: " + itemName);

        if (itemName == "food")
        {
            eatButton.SetActive(true);
            dropButton.SetActive(true);
        }
        else
        {
            eatButton.SetActive(false);
            dropButton.SetActive(false);
        }
    }
}
