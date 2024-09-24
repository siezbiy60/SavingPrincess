using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldScript : MonoBehaviour
{
    public int goldValue = 1; // Altýnýn deðeri, Inspector'dan ayarlanabilir.

    // Gold'a çarpýldýðýnda tetiklenecek fonksiyon
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer çarpan nesne "Player" tag'ine sahipse
        if (other.CompareTag("Player"))
        {
            // Player'ýn Gold toplama fonksiyonunu çaðýr ve goldValue kadar altýn ekle
            other.GetComponent<PlayerController>().CollectGold(goldValue);
            // Altýný yok et
            Destroy(gameObject);
        }
    }
}
