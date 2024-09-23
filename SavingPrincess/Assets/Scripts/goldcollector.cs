using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldcollector : MonoBehaviour
{
    public GoldManager goldManager; // GoldManager referansý

    void OnTriggerEnter(Collider other)
    {
        // Eðer çarpan nesne "Player" ise
        if (other.CompareTag("Player"))
        {
            goldManager.AddGold(10); // 10 altýn ekle
            Destroy(gameObject); // Item'ý yok et
        }
    }
}
