using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public ItemSlot[] itemSlot; // Item slotlarýnýn dizisi


   



    //Item açýklama slotou

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

    [SerializeField]
    private int maxNumberOfItem;

    public GameObject selectedShader;
    private InventoryManager inventoryManager;


    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }


    // Yeni item ekleme
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {


        //check to see if slot is already full
        if (isFull)
            return quantity;

        //update name
        this.name = itemName;

        //update image
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        this.itemDescription = itemDescription;
        //update quantity

        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItem)
        {
            quantityText.text = maxNumberOfItem.ToString();
            quantityText.enabled = true;
            isFull = true;



            int extraItems = this.quantity - maxNumberOfItem;
            this.quantity = maxNumberOfItem;
            return extraItems;

        }
        //update quantity text
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;


        return 0;

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
        if (itemDescriptionImage.sprite == null)
            itemDescriptionImage.sprite = emptySprite;
    }
    public void OnRightClick()
    {

    }
    // UI'yi güncelleme fonksiyonu
    public void UpdateItemUI()
    {
        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;
    }
}




//public bool isFull;
//// ItemSlot ile ilgili deðiþkenler
//public string itemName;
//public int quantity;
//public Sprite itemSprite;


//[SerializeField]
//private TMP_Text quantityText;


//[SerializeField]
//private Image itemImage;


//public void AddItem(string itemName, int quantity, Sprite itemSprite)
//    {

//this.itemName = itemName;
//    this.quantity = quantity;   
//    this.itemSprite = itemSprite;
//    isFull = true;
//    quantityText.text=quantity.ToString();
//    quantityText.enabled=true;
//    itemImage.sprite=itemSprite;
//}
