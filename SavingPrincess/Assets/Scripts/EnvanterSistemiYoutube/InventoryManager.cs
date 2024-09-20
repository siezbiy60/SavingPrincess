using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu; // Envanter paneli
    public GameObject StorePanel; // D�kkan paneli
    public bool menuActivated;

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
            }
            else
            {
                InventoryMenu.SetActive(true);
                menuActivated = true;
            }
        }
    }
}