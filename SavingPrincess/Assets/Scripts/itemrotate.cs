using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemrotate : MonoBehaviour
{
    public float rotationSpeed = 50f; // D�nme h�z�
    public float moveDistance = 0.5f; // Yukar� a�a�� hareket mesafesi
    public float moveSpeed = 2f; // Yukar� a�a�� hareket h�z�

    private Vector3 startPosition; // Ba�lang�� pozisyonu
    private float offset; // Yukar� a�a�� hareket i�in offset

    void Start()
    {
        startPosition = transform.position; // Ba�lang�� pozisyonunu kaydet
    }

    void Update()
    {
        // Nesneyi d�nd�r
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Yukar� a�a�� hareket
        offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance; // Sadece yukar� a�a�� hareket
        transform.position = startPosition + new Vector3(0, offset, 0); // Pozisyonu g�ncelle
    }
}
