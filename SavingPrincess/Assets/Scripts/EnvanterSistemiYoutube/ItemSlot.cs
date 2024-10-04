
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

//        // UI'yi g�ncelle
//        UpdateItemUI();
//    }

//    // Miktar� art�rarak UI'yi g�ncelle
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
//        // Sa� t�klama i�lemleri
//    }

//    // UI'yi g�ncelleme fonksiyonu
//    public void UpdateItemUI()
//    {
//        quantityText.text = quantity.ToString();
//        quantityText.enabled = true;
//        itemImage.sprite = itemSprite;
//    }

//    // Item se�imini s�f�rlama fonksiyonu
//    public void ResetItemSelection()
//    {
//        thisItemSelected = false;
//        selectedShader.SetActive(false);
//        ItemDescriptionNameText.text = ""; // A��klama ad�n� s�f�rla
//        ItemDescriptionText.text = ""; // A��klama metnini s�f�rla
//        itemDescriptionImage.sprite = emptySprite; // A��klama g�r�nt�s�n� s�f�rla
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
    public HealthScript healthScript; // HealthScript referans�

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
        healthScript = GameObject.Find("Player").GetComponent<HealthScript>(); // HealthScript referans�n� al
    }

    // Yeni item ekleme
    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        isFull = true;
        this.itemDescription = itemDescription;

        // UI'yi g�ncelle
        UpdateItemUI();
    }

    // Miktar� art�rarak UI'yi g�ncelle
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

        // E�er a��klama resmi bo�sa, bo� sprite'� ayarlay�n
        if (itemDescriptionImage.sprite == null)
            itemDescriptionImage.sprite = emptySprite;

        // Item actions g�ster
        inventoryManager.ShowItemActions(itemName);
    }

    public void OnRightClick()
    {
        // Sa� t�klama i�lemleri
    }

    // UI'yi g�ncelleme fonksiyonu
    public void UpdateItemUI()
    {
        quantityText.text = quantity > 0 ? quantity.ToString() : ""; // E�er miktar 0'dan b�y�kse g�ster
        quantityText.enabled = quantity > 0; // Miktar 0 ise g�r�nmez yap
        itemImage.sprite = itemSprite; // Item g�rselini g�ncelle
    }

    // Item kullanma fonksiyonu
    public void UseItem()
    {
        {

            quantity--; // Miktar� bir azalt
            if (quantity <= 0)
            {
                inventoryManager.RemoveItemFromSlot(this); // InventoryManager �zerinden slotu kald�r
                ClearSlot(); // Slotu temizle
                ResetItemSelection(); // Se�imi s�f�rla
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
        UpdateItemUI(); // UI'yi g�ncelle
    }

    // Item se�imini s�f�rlama fonksiyonu
    public void ResetItemSelection()
    {
        thisItemSelected = false;
        selectedShader.SetActive(false);
        ItemDescriptionNameText.text = ""; // A��klama ad�n� s�f�rla
        ItemDescriptionText.text = ""; // A��klama metnini s�f�rla
        itemDescriptionImage.sprite = emptySprite; // A��klama g�r�nt�s�n� s�f�rla
    }
}
