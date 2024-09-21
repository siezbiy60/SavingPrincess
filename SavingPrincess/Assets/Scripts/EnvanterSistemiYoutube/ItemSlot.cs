using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnLeftClick();
        }

    }

    public void OnLeftClick()
    {

        selectedShader.SetActive(true);
        thisSelected = true;
    }



    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    Debug.Log("Týklanan buton: " + eventData.button.ToString());
    //    if (eventData.button == PointerEventData.InputButton.Left)
    //    {
    //        OnLeftClick();
    //    }
    //    //if (eventData.button == PointerEventData.InputButton.Right)
    //    //{
    //    //    OnRightClick();
    //    //}
    //}


    //public void OnLeftClick()
    //{
    //    selectedShader.SetActive(true);
    //    thisSelected = true;
    //}
}
