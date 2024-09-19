using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopTrigger : MonoBehaviour
{

    public GameObject shopPanel;       // UI Paneli
    public TextMeshProUGUI interactText;  // TextMeshProUGUI bile�eni tan�mland�
    private bool isPlayerInRange = false;  // Oyuncunun belirlenen alanda olup olmad���n� kontrol eden de�i�ken

    void Start()
    {
        shopPanel.SetActive(false);    // Panel ba�lang��ta kapal�
      //  interactText.enabled = false;  // Mesaj ba�lang��ta gizli
    }

    void Update()
    {
        // E�er oyuncu belirlenen alan i�indeyse ve E tu�una basarsa
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            shopPanel.SetActive(true);  // Paneli a�
            interactText.enabled = false;  // Mesaj� gizle
        }
    }

    // Oyuncu trigger alan�na girdi�inde
    private void OnTriggerEnter2D(Collider2D other)  // 2D oyun i�in
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactText.enabled = true;  // Mesaj� g�ster
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("Karakter trigger alan�na girdi!");  // Bu mesaj� Console'da g�rebilmelisin
            isPlayerInRange = true;
            interactText.enabled = true;
        }
    }

    // Oyuncu trigger alan�ndan ��kt���nda
    private void OnTriggerExit2D(Collider2D other)  // 2D oyun i�in
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactText.enabled = false;  // Mesaj� gizle
            shopPanel.SetActive(false);    // Oyuncu alandan ��k�nca paneli kapat
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("Karakter trigger alan�ndan ��kt�!");  // Console'da g�rmelisin
            isPlayerInRange = false;
            interactText.enabled = false;
            shopPanel.SetActive(false);
        }
    }

}