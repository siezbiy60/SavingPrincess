using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{

    //public string itemName;
    //public int quantity;
    //public Sprite itemSprite;
    public bool isFull;
    // ItemSlot ile ilgili deðiþkenler
    public string itemName;
    public int quantity;
    public Sprite itemSprite;


    [SerializeField]
    private TMP_Text quantityText;


    [SerializeField]
    private Image itemImage;



    public GameObject selectedShader;
    public bool thisSelected;

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {

        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        isFull = true;
        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;
    }

}
    
