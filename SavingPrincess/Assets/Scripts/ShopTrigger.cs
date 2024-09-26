using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopTrigger : MonoBehaviour
{
    public GameObject shopPanel; // D�kkan paneli
    public Button closeButton; // D�kkan� kapatacak buton
    private bool isPlayerInShopArea = false; // Karakterin d�kkanda olup olmad���n� kontrol eder
    private PlayerController playerController;

    void Start()
    {
        shopPanel.SetActive(false); // Ba�lang��ta d�kkan paneli kapal�

        // Buton t�klama olay�n� dinleyici olarak ekle
        closeButton.onClick.AddListener(CloseShopPanel);
    }

    void Update()
    {
        if (isPlayerInShopArea && Input.GetKeyDown(KeyCode.E))
        {
            bool isShopPanelActive = !shopPanel.activeSelf;
            shopPanel.SetActive(isShopPanelActive); // E'ye bas�ld���nda paneli a�/kapat

            if (isShopPanelActive)
            {
                playerController.DisableMovement(); // Panel a��ld���nda hareketi durdur
            }
            else
            {
                playerController.EnableMovement(); // Panel kapand���nda hareketi tekrar ba�lat
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInShopArea = true;
            playerController = other.GetComponent<PlayerController>(); // PlayerController'a eri�
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInShopArea = false;
            shopPanel.SetActive(false); // D�kkan panelini kapat
            playerController.EnableMovement(); // Panel kapand���nda hareketi tekrar ba�lat
        }
    }

    // Butona bas�ld���nda paneli kapatma i�lemi
    public void CloseShopPanel()
    {
        shopPanel.SetActive(false); // D�kkan panelini kapat
        playerController.EnableMovement(); // Panel kapan�nca hareketi tekrar ba�lat
    }
}