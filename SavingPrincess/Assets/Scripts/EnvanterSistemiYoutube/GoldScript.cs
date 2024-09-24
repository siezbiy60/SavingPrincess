using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldScript : MonoBehaviour
{
    public int goldValue = 1; // Alt�n�n de�eri, Inspector'dan ayarlanabilir.

    // Gold'a �arp�ld���nda tetiklenecek fonksiyon
    private void OnTriggerEnter2D(Collider2D other)
    {
        // E�er �arpan nesne "Player" tag'ine sahipse
        if (other.CompareTag("Player"))
        {
            // Player'�n Gold toplama fonksiyonunu �a��r ve goldValue kadar alt�n ekle
            other.GetComponent<PlayerController>().CollectGold(goldValue);
            // Alt�n� yok et
            Destroy(gameObject);
        }
    }
}
