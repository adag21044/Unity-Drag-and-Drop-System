using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Camera cam; // Ana kamera
    Vector3 startDragPos; // Objeyi tutarken başlangıç pozisyonu
    Vector3 currentMousePos; // Fare pozisyonu
    bool holding = false; // Fare basılı mı?
    public float minDragDistance = 0.5f; // Minimum kaydırma mesafesi

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Fareye basılıyken kaydırma işlemi
        if (holding)
        {
            // Fare pozisyonunu dünya pozisyonuna dönüştür
            Vector3 mouseScreenPos = Input.mousePosition;
            mouseScreenPos.z = cam.WorldToScreenPoint(transform.position).z; // Kameradan objeye olan mesafeyi ayarla
            currentMousePos = cam.ScreenToWorldPoint(mouseScreenPos); // Dünya pozisyonunu hesapla

            // Kaydırma mesafesini kontrol et
            float dragDistance = Vector3.Distance(startDragPos, currentMousePos);
            if (dragDistance > minDragDistance) // Eğer minimum mesafeyi geçtiyse
            {
                transform.position = currentMousePos; // Objeyi fare pozisyonuna taşı
            }
        }
    }

    private void OnMouseDown()
    {
        holding = true; // Fare basılı

        // Objenin başlangıç pozisyonunu kaydet
        startDragPos = transform.position;
    }

    private void OnMouseUp()
    {
        holding = false; // Fare bırakıldı
    }
}