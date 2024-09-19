using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopTrigger : MonoBehaviour
{
    
    public TextMeshProUGUI interactText;  // TextMeshProUGUI bileþeni tanýmlandý
    public GameObject shopPanel;      // Dükkan paneli
    private bool isPlayerInRange = false;
    private PlayerController playerMovement;  // Karakter hareketi kontrolü

    void Start()
    {
        shopPanel.SetActive(false);
        interactText.enabled = false;

        // Karakter hareket script'ine eriþ
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenShop();
        }
    }

    private void OpenShop()
    {
        shopPanel.SetActive(true);
        interactText.enabled = false;
        playerMovement.DisableMovement();  // Karakter hareketini durdur
    
    }

    // Trigger alanýna girince
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactText.enabled = true;
        }
    }

    // Trigger alanýndan çýkýnca
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactText.enabled = false;
            CloseShop();  // Oyuncu alan dýþýna çýkarsa dükkâný kapat
        }
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        playerMovement.EnableMovement();  // Karakterin hareketini tekrar baþlat
    }
}