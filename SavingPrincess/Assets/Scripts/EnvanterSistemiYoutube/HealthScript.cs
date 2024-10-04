using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider healthSlider; // Can bar� slider
    public Button increaseHealthButton; // Can art��� i�in buton
    public int healthIncreaseAmount = 10; // Can art�� miktar�

    void Start()
    {
        // Butona t�klanma olay�n� dinliyoruz
        increaseHealthButton.onClick.AddListener(IncreaseHealth);
    }

    // Can art��� fonksiyonu
  public  void IncreaseHealth()
    {
        // Mevcut can� art�r�yoruz, fakat slider'�n maksimum de�eri a��lm�yor
        healthSlider.value = Mathf.Min(healthSlider.maxValue, healthSlider.value + healthIncreaseAmount);
    }
}
