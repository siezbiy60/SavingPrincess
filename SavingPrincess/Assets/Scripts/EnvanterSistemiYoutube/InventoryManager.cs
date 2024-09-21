using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu; // Envanter paneli
    public GameObject StorePanel; // D�kkan paneli
    public bool menuActivated;

    public PlayerController playerMovement;

    public ItemSlot[] itemSlot; // Dizinin private olmas�n� sa�lamak

    void Start()
    {
        // Ba�lang��ta envanter kapal�
        InventoryMenu.SetActive(false);
        menuActivated = false;
    }

    void Update()
    {
        // Tab tu�una bas�ld���nda envanter a�/kapat i�lemi yap�l�yor, ama d�kkan paneli a��k de�ilse
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
    public void AddItem(string itemName, int quantity, Sprite sprite)
    {

        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull==false)
            {
                itemSlot[i].AddItem(itemName, quantity, sprite);
                return;
            }


        }

    }

}