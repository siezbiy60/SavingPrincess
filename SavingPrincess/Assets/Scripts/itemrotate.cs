using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemrotate : MonoBehaviour
{

    public float rotationSpeed = 100f; // D�nme h�z�

    void Update()
    {
        // D�nme i�lemi
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
