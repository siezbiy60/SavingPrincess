using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldcollector : MonoBehaviour
{
    public GoldManager goldManager; // GoldManager referans�

    void OnTriggerEnter(Collider other)
    {
        // E�er �arpan nesne "Player" ise
        if (other.CompareTag("Player"))
        {
            goldManager.AddGold(10); // 10 alt�n ekle
            Destroy(gameObject); // Item'� yok et
        }
    }
}
