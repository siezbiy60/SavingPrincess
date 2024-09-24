using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Rigidbody2D))]
//public class PlayerController : MonoBehaviour
//{
//    private bool canMove = true;  // Hareket kontrol� i�in de�i�ken

//    private float inputPower;

//    public float moveSpeed;
//    public int direction;
//    public bool isWalking;

//    private Rigidbody2D rb;
//    private Animator anim;
//    public Vector2 velocity;
//    private float horizontal;
//    private float vertical;
//    private void Start()
//    {
//        rb = gameObject.GetComponent<Rigidbody2D>();

//        anim = GetComponent<Animator>();
//    }

//    private void Update()
//    {
//        horizontal = Input.GetAxis("Horizontal");
//        vertical = Input.GetAxisRaw("Vertical");


//        GetComponent<SpriteRenderer>().flipX = (horizontal < 0);


//        inputPower = new Vector2(horizontal, vertical).magnitude;




//        if (inputPower != 0)
//            direction = Mathf.RoundToInt(Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg);


//        velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);



//        anim.SetBool("isWalking", (inputPower > 0));
//        anim.SetInteger("Direction", direction);

//        if (canMove)
//        {
//            velocity.x = Input.GetAxisRaw("Horizontal");
//            velocity.y = Input.GetAxisRaw("Vertical");
//        }
//        else
//        {
//            velocity = Vector2.zero;  // Panel a��kken hareket duracak
//                                      // Y�nlendirmeyi de s�f�rla
//            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
//        }

//    }
//    private void FixedUpdate()
//    {
//        rb.velocity = velocity;

//    }
//    public void DisableMovement()
//    {
//        canMove = false;
//    }
//    public void EnableMovement()
//    {
//        canMove = true;
//    }


//}

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{


    public int goldAmount = 0; // Ba�lang��taki alt�n miktar�
    
    public TextMeshProUGUI goldText4;

    private bool canMove = true;  // Hareket kontrol� i�in de�i�ken

    private float inputPower;

    public float moveSpeed;
    public int direction;
    public bool isWalking;

    private Rigidbody2D rb;
    private Animator anim;
    public Vector2 velocity;
    private float horizontal;
    private float vertical;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

     

    }
    public void CollectGold(int amount)
    {
        goldAmount += amount; // Alt�n miktar�n� gelen miktar kadar artt�r
        UpdateGoldUI(); // UI'yi g�ncelle
    }

    // UI'deki alt�n miktar�n� g�ncelleyen fonksiyon
    void UpdateGoldUI()
    {
        goldText4.text = "Gold: " + goldAmount.ToString();
    }


    private void Update()
    {
        // Hareket girdilerini al
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // canMove kontrol�: Hareket ve d�nme i�lemleri sadece canMove true ise yap�l�r
        if (canMove)
        {
            // Karakterin sa�a veya sola d�nmesi
            GetComponent<SpriteRenderer>().flipX = (horizontal < 0);

            // Hareket g�c�
            inputPower = new Vector2(horizontal, vertical).magnitude;

            if (inputPower != 0)
                direction = Mathf.RoundToInt(Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg);

            velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);

            anim.SetBool("isWalking", (inputPower > 0));
            anim.SetInteger("Direction", direction);
        }
        else
        {
            // canMove false ise hareket duracak, animasyonlar ve y�n s�f�rlanacak
            velocity = Vector2.zero;
            anim.SetBool("isWalking", false);
            anim.SetInteger("Direction", 0);
        }
    }

    private void FixedUpdate()
    {
        // Fiziksel hareketi uygula
        rb.velocity = velocity;
    }

    // Hareketi tamamen devre d��� b�rakma
    public void DisableMovement()
    {
        canMove = false;
    }

    // Hareketi yeniden etkinle�tirme
    public void EnableMovement()
    {
        canMove = true;
    }

}