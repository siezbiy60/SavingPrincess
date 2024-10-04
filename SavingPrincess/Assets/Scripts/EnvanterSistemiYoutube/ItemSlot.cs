
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

//public class ItemSlot : MonoBehaviour, IPointerClickHandler
//{
//    public Image itemDescriptionImage;
//    public TMP_Text ItemDescriptionNameText;
//    public TMP_Text ItemDescriptionText;

//    public bool isFull;
//    public string itemName;
//    public int quantity;
//    public Sprite itemSprite;
//    public string itemDescription;
//    public Sprite emptySprite;

//    [SerializeField]
//    private TMP_Text quantityText;

//    [SerializeField]
//    private Image itemImage;
//    public bool thisItemSelected;

//    public GameObject selectedShader;
//    private InventoryManager inventoryManager;

//    private void Start()
//    {
//        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
//    }

//    // Yeni item ekleme
//    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
//    {
//        this.itemName = itemName;
//        this.quantity = quantity;
//        this.itemSprite = itemSprite;
//        isFull = true;
//        this.itemDescription = itemDescription;

//        // UI'yi güncelle
//        UpdateItemUI();
//    }

//    // Miktarý artýrarak UI'yi güncelle
//    public void AddQuantity(int additionalQuantity)
//    {
//        quantity += additionalQuantity;
//        UpdateItemUI();
//    }

//    public void OnPointerClick(PointerEventData eventData)
//    {
//        if (eventData.button == PointerEventData.InputButton.Left)
//        {
//            OnLeftClick();
//        }
//        if (eventData.button == PointerEventData.InputButton.Right)
//        {
//            OnRightClick();
//        }
//    }

//    public void OnLeftClick()
//    {
//        inventoryManager.DeselectAllSlots();
//        selectedShader.SetActive(true);
//        thisItemSelected = true;
//        ItemDescriptionNameText.text = itemName;
//        ItemDescriptionText.text = itemDescription;
//        itemDescriptionImage.sprite = itemSprite;
//        if (itemDescriptionImage.sprite == null)
//            itemDescriptionImage.sprite = emptySprite;

//        inventoryManager.ShowItemActions(itemName);
//    }

//    public void OnRightClick()
//    {
//        // Sað týklama iþlemleri
//    }

//    // UI'yi güncelleme fonksiyonu
//    public void UpdateItemUI()
//    {
//        quantityText.text = quantity.ToString();
//        quantityText.enabled = true;
//        itemImage.sprite = itemSprite;
//    }

//    // Item seçimini sýfýrlama fonksiyonu
//    public void ResetItemSelection()
//    {
//        thisItemSelected = false;
//        selectedShader.SetActive(false);
//        ItemDescriptionNameText.text = ""; // Açýklama adýný sýfýrla
//        ItemDescriptionText.text = ""; // Açýklama metnini sýfýrla
//        itemDescriptionImage.sprite = emptySprite; // Açýklama görüntüsünü sýfýrla
//    }

//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public HealthScript healthScript; // HealthScript referansý

    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    public bool isFull;
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public string itemDescription;
    public Sprite emptySprite;

    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;
    public bool thisItemSelected;

    public GameObject selectedShader;
    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        healthScript = GameObject.Find("Player").GetComponent<HealthScript>(); // HealthScript referansýný al
    }

    // Yeni item ekleme
    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        isFull = true;
        this.itemDescription = itemDescription;

        // UI'yi güncelle
        UpdateItemUI();
    }

    // Miktarý artýrarak UI'yi güncelle
    public void AddQuantity(int additionalQuantity)
    {
        quantity += additionalQuantity;
        UpdateItemUI();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;

        // Eðer açýklama resmi boþsa, boþ sprite'ý ayarlayýn
        if (itemDescriptionImage.sprite == null)
            itemDescriptionImage.sprite = emptySprite;

        // Item actions göster
        inventoryManager.ShowItemActions(itemName);
    }

    public void OnRightClick()
    {
        // Sað týklama iþlemleri
    }

    // UI'yi güncelleme fonksiyonu
    public void UpdateItemUI()
    {
        quantityText.text = quantity > 0 ? quantity.ToString() : ""; // Eðer miktar 0'dan büyükse göster
        quantityText.enabled = quantity > 0; // Miktar 0 ise görünmez yap
        itemImage.sprite = itemSprite; // Item görselini güncelle
    }

    // Item kullanma fonksiyonu
    public void UseItem()
    {
        {

            quantity--; // Miktarý bir azalt
            if (quantity <= 0)
            {
                inventoryManager.RemoveItemFromSlot(this); // InventoryManager üzerinden slotu kaldýr
                ClearSlot(); // Slotu temizle
                ResetItemSelection(); // Seçimi sýfýrla
            }
            UpdateItemUI();
        }
    }

    // Slotu temizleme fonksiyonu
    public void ClearSlot()
    {
        itemName = "";
        quantity = 0;
        itemSprite = emptySprite;
        isFull = false;
        UpdateItemUI(); // UI'yi güncelle
    }

    // Item seçimini sýfýrlama fonksiyonu
    public void ResetItemSelection()
    {
        thisItemSelected = false;
        selectedShader.SetActive(false);
        ItemDescriptionNameText.text = ""; // Açýklama adýný sýfýrla
        ItemDescriptionText.text = ""; // Açýklama metnini sýfýrla
        itemDescriptionImage.sprite = emptySprite; // Açýklama görüntüsünü sýfýrla
    }
}
