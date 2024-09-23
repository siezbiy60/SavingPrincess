using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
//public class PlayerController : MonoBehaviour
//{
//    private bool canMove = true;  // Hareket kontrolü için deðiþken

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
//            velocity = Vector2.zero;  // Panel açýkken hareket duracak
//                                      // Yönlendirmeyi de sýfýrla
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


    private int goldAmount;
    public TMP_Text goldText; // UI'da gösterilecek metin


    private bool canMove = true;  // Hareket kontrolü için deðiþken

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

        goldAmount = 0;
        UpdateGoldUI(); // Baþlangýçta UI'ý güncelle

    }
    public void AddGold(int amount)
    {
        goldAmount += amount;
        UpdateGoldUI();
    }

    private void UpdateGoldUI()
    {
        goldText.text = goldAmount.ToString(); // UI'deki texti güncelle
    }

    private void Update()
    {
        // Hareket girdilerini al
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // canMove kontrolü: Hareket ve dönme iþlemleri sadece canMove true ise yapýlýr
        if (canMove)
        {
            // Karakterin saða veya sola dönmesi
            GetComponent<SpriteRenderer>().flipX = (horizontal < 0);

            // Hareket gücü
            inputPower = new Vector2(horizontal, vertical).magnitude;

            if (inputPower != 0)
                direction = Mathf.RoundToInt(Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg);

            velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);

            anim.SetBool("isWalking", (inputPower > 0));
            anim.SetInteger("Direction", direction);
        }
        else
        {
            // canMove false ise hareket duracak, animasyonlar ve yön sýfýrlanacak
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

    // Hareketi tamamen devre dýþý býrakma
    public void DisableMovement()
    {
        canMove = false;
    }

    // Hareketi yeniden etkinleþtirme
    public void EnableMovement()
    {
        canMove = true;
    }

}