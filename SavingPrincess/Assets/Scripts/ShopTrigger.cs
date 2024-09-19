using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopTrigger : MonoBehaviour
{
    
    public TextMeshProUGUI interactText;  // TextMeshProUGUI bile�eni tan�mland�
    public GameObject shopPanel;      // D�kkan paneli
    private bool isPlayerInRange = false;
    private PlayerController playerMovement;  // Karakter hareketi kontrol�

    void Start()
    {
        shopPanel.SetActive(false);
        interactText.enabled = false;

        // Karakter hareket script'ine eri�
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

    // Trigger alan�na girince
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactText.enabled = true;
        }
    }

    // Trigger alan�ndan ��k�nca
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactText.enabled = false;
            CloseShop();  // Oyuncu alan d���na ��karsa d�kk�n� kapat
        }
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        playerMovement.EnableMovement();  // Karakterin hareketini tekrar ba�lat
    }
}