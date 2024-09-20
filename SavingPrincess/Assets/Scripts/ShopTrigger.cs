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
    public Text interakttext;

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
        playerMovement.isWalking=true;
        playerMovement.direction=0;

      //  Time.timeScale=0; //karakteri durdurma (ilerde sorun ��karabilir)
        shopPanel.SetActive(true);
        interactText.enabled = false;
        playerMovement.DisableMovement();  // Karakter hareketini durdur
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // Y�nlendirmeyi s�f�rla

    }

    // Trigger alan�na girince
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactText.enabled = true;
            playerMovement.isWalking = true;

        }
    }
    public void CloseShop()
    {
      //  Time.timeScale = 1;  //karakteri durdurma (ilerde sorun ��karabilir)

        shopPanel.SetActive(false);
        playerMovement.EnableMovement();
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

  
}