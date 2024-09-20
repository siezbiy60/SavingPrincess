using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public GameObject storePanel;
    public PlayerController playerController;

    void Update()
    {
        if (storePanel.activeSelf)
        {
            playerController.DisableMovement(); // Ma�aza a��ld���nda hareketi devre d��� b�rak
        }
        else
        {
            playerController.EnableMovement(); // Ma�aza kapand���nda hareketi etkinle�tir
        }
    }
}
