using System;
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

    public ItemSlot[] itemSlot; // Dizinin private olmasýný saðlamak


    

    void Start()
    {
        // Baþlangýçta envanter kapalý
        InventoryMenu.SetActive(false);
        menuActivated = false;
    }

    void Update()
    {
        // Tab tuþuna basýldýðýnda envanter aç/kapat iþlemi yapýlýyor, ama dükkan paneli açýk deðilse
        if (Input.GetKeyDown(KeyCode.Tab) && !StorePanel.activeSelf)
        {
            if (menuActivated)
            {
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
    public void AddItem(string itemName, int quantity, Sprite sprite,string itemDescription)
    {
        // Ayný item var mý kontrol et
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull && itemSlot[i].itemName == itemName)
            {
                // Ayný isimde item varsa, miktarýný artýr
                itemSlot[i].AddQuantity(quantity);
                return;
            }
        }

        // Eðer ayný item yoksa, boþ bir slot bul ve doldur
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
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }

}