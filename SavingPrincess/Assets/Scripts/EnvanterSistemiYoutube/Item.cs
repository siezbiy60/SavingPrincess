//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Item : MonoBehaviour
//{
//    [SerializeField]
//    private string itemName;


//    [SerializeField]
//    private int quantity;

//    [SerializeField]
//    private Sprite sprite;

//    [TextArea]
//    [SerializeField]
//    private string itemDescription;

//    public GameObject itemPrefab; // Prefab referansý

//    private InventoryManager InventoryManager;

//    // Start is called before the first frame update
//    void Start()
//    {
//        InventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();

//    }


//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.tag == "Player")
//        {
//            InventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
//            Destroy(gameObject);
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName; // Item adý

    [SerializeField]
    private int quantity; // Miktar

    [SerializeField]
    private Sprite sprite; // Görsel

    [TextArea]
    [SerializeField]
    private string itemDescription; // Açýklama

    public GameObject itemPrefab; // Prefab referansý

    private InventoryManager inventoryManager;

    // Property for itemNam
    public string ItemName
    {
        get { return itemName; }
    }

    // Property for quantity
    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Debug mesajý ekleyin
            Debug.Log("Item alýndý: " + itemName);

            inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            Destroy(gameObject);
        }
    }
}
