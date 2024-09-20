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


    private InventoryManager InventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        InventoryManager=GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            InventoryManager.AddItem(itemName,quantity,sprite);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
