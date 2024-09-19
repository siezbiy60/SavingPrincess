using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopTrigger : MonoBehaviour
{

    public GameObject shopPanel;       // UI Paneli
    public TextMeshProUGUI interactText;  // TextMeshProUGUI bileþeni tanýmlandý
    private bool isPlayerInRange = false;  // Oyuncunun belirlenen alanda olup olmadýðýný kontrol eden deðiþken

    void Start()
    {
        shopPanel.SetActive(false);    // Panel baþlangýçta kapalý
      //  interactText.enabled = false;  // Mesaj baþlangýçta gizli
    }

    void Update()
    {
        // Eðer oyuncu belirlenen alan içindeyse ve E tuþuna basarsa
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            shopPanel.SetActive(true);  // Paneli aç
            interactText.enabled = false;  // Mesajý gizle
        }
    }

    // Oyuncu trigger alanýna girdiðinde
    private void OnTriggerEnter2D(Collider2D other)  // 2D oyun için
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactText.enabled = true;  // Mesajý göster
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("Karakter trigger alanýna girdi!");  // Bu mesajý Console'da görebilmelisin
            isPlayerInRange = true;
            interactText.enabled = true;
        }
    }

    // Oyuncu trigger alanýndan çýktýðýnda
    private void OnTriggerExit2D(Collider2D other)  // 2D oyun için
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactText.enabled = false;  // Mesajý gizle
            shopPanel.SetActive(false);    // Oyuncu alandan çýkýnca paneli kapat
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("Karakter trigger alanýndan çýktý!");  // Console'da görmelisin
            isPlayerInRange = false;
            interactText.enabled = false;
            shopPanel.SetActive(false);
        }
    }

}