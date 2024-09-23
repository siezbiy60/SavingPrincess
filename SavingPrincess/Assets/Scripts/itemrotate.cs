using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemrotate : MonoBehaviour
{
    public float rotationSpeed = 50f; // Dönme hýzý
    public float moveDistance = 0.5f; // Yukarý aþaðý hareket mesafesi
    public float moveSpeed = 2f; // Yukarý aþaðý hareket hýzý

    private Vector3 startPosition; // Baþlangýç pozisyonu
    private float offset; // Yukarý aþaðý hareket için offset

    void Start()
    {
        startPosition = transform.position; // Baþlangýç pozisyonunu kaydet
    }

    void Update()
    {
        // Nesneyi döndür
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Yukarý aþaðý hareket
        offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance; // Sadece yukarý aþaðý hareket
        transform.position = startPosition + new Vector3(0, offset, 0); // Pozisyonu güncelle
    }
}
