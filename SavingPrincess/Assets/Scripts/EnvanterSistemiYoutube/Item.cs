using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;


    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

    [TextArea]
    [SerializeField]
    private string itemDescription;

    private InventoryManager InventoryManager;



    // Start is called before the first frame update
    void Start()
    {
        InventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          int leftOverItems=  InventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            if(leftOverItems <= 0) 
            Destroy(gameObject);
            else
                quantity = leftOverItems;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            // Eðer item altýn ise, sadece UI'daki sayýyý artýr
            if (itemName == "Gold")
            {
                // Gold miktarýný PlayerController üzerinden artýr
                collision.gameObject.GetComponent<PlayerController>().AddGold(quantity);
            }

            Destroy(gameObject); // Item'ý yok et
        }



        }

    // Update is called once per frame
    void Update()
    {

    }
}