using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;


    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;
   

    private InventoryManager InventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        InventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;  // �temin hareket etmesini engeller
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")  // Karakterin "Player" tag'�na sahip oldu�undan emin olun
        {
            // �temin bilgilerini envantere ekle
            string itemName = GetComponent<Item>().itemName;
            int quantity = GetComponent<Item>().quantity;
            Sprite sprite = GetComponent<Item>().sprite;

            // Envantere item ekleme
            FindObjectOfType<InventoryManager>().AddItem(itemName, quantity, sprite);

            // �temi yok et
            Destroy(gameObject);  // �temin yok edilmesi
            Destroy(GetComponent<Rigidbody>());

        }
    }
}
//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if(collision.gameObject.tag=="Player")
//        {
//            InventoryManager.AddItem(itemName,quantity,sprite);
//            Destroy(gameObject);
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
