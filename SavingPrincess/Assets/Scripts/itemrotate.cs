using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemrotate : MonoBehaviour
{

    public float rotationSpeed = 100f; // Dönme hýzý

    void Update()
    {
        // Dönme iþlemi
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
