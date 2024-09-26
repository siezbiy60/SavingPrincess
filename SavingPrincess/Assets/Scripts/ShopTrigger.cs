using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopTrigger : MonoBehaviour
{
    public GameObject shopPanel; // Dükkan paneli
    public Button closeButton; // Dükkaný kapatacak buton
    private bool isPlayerInShopArea = false; // Karakterin dükkanda olup olmadýðýný kontrol eder
    private PlayerController playerController;

    void Start()
    {
        shopPanel.SetActive(false); // Baþlangýçta dükkan paneli kapalý

        // Buton týklama olayýný dinleyici olarak ekle
        closeButton.onClick.AddListener(CloseShopPanel);
    }

    void Update()
    {
        if (isPlayerInShopArea && Input.GetKeyDown(KeyCode.E))
        {
            bool isShopPanelActive = !shopPanel.activeSelf;
            shopPanel.SetActive(isShopPanelActive); // E'ye basýldýðýnda paneli aç/kapat

            if (isShopPanelActive)
            {
                playerController.DisableMovement(); // Panel açýldýðýnda hareketi durdur
            }
            else
            {
                playerController.EnableMovement(); // Panel kapandýðýnda hareketi tekrar baþlat
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInShopArea = true;
            playerController = other.GetComponent<PlayerController>(); // PlayerController'a eriþ
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInShopArea = false;
            shopPanel.SetActive(false); // Dükkan panelini kapat
            playerController.EnableMovement(); // Panel kapandýðýnda hareketi tekrar baþlat
        }
    }

    // Butona basýldýðýnda paneli kapatma iþlemi
    public void CloseShopPanel()
    {
        shopPanel.SetActive(false); // Dükkan panelini kapat
        playerController.EnableMovement(); // Panel kapanýnca hareketi tekrar baþlat
    }
}