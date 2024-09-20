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
            playerController.DisableMovement(); // Maðaza açýldýðýnda hareketi devre dýþý býrak
        }
        else
        {
            playerController.EnableMovement(); // Maðaza kapandýðýnda hareketi etkinleþtir
        }
    }
}
