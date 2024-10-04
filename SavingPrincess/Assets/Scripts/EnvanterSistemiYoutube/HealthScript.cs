using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider healthSlider; // Can barý slider
    public Button increaseHealthButton; // Can artýþý için buton
    public int healthIncreaseAmount = 10; // Can artýþ miktarý

    void Start()
    {
        // Butona týklanma olayýný dinliyoruz
        increaseHealthButton.onClick.AddListener(IncreaseHealth);
    }

    // Can artýþý fonksiyonu
  public  void IncreaseHealth()
    {
        // Mevcut caný artýrýyoruz, fakat slider'ýn maksimum deðeri aþýlmýyor
        healthSlider.value = Mathf.Min(healthSlider.maxValue, healthSlider.value + healthIncreaseAmount);
    }
}
