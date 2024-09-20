using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu; // Envanter paneli
    public GameObject StorePanel; // Dükkan paneli
    public bool menuActivated;

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
            }
            else
            {
                InventoryMenu.SetActive(true);
                menuActivated = true;
            }
        }
    }
}