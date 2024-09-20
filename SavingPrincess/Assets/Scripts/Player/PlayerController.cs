using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
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

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");


        GetComponent<SpriteRenderer>().flipX = (horizontal < 0);


        inputPower = new Vector2(horizontal, vertical).magnitude;




        if (inputPower != 0)
            direction = Mathf.RoundToInt(Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg);


        velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);



        anim.SetBool("isWalking", (inputPower > 0));
        anim.SetInteger("Direction", direction);

        if (canMove)
        {
            velocity.x = Input.GetAxisRaw("Horizontal");
            velocity.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            velocity = Vector2.zero;  // Panel a��kken hareket duracak
                                      // Y�nlendirmeyi de s�f�rla
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = velocity;

    }
    public void DisableMovement()
    {
        canMove = false;
    }
    public void EnableMovement()
    {
        canMove = true;
    }


}

//}
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

//    private int GetDirectionFromInput(float horizontal, float vertical)
//    {
//        if (vertical > 0) return 0;    // Yukar�
//        if (vertical < 0) return 180;  // A�a��
//        if (horizontal > 0) return 90; // Sa�
//        if (horizontal < 0) return 270; // Sol
//        return 0; // Varsay�lan olarak yukar�
//    }
//    private void Update()
//    {
//        if (canMove)
//        {
//            horizontal = Input.GetAxis("Horizontal");
//            vertical = Input.GetAxis("Vertical");

//            // Hareket y�n�ne g�re sprite'� d�nd�r
//            GetComponent<SpriteRenderer>().flipX = (horizontal < 0);

//            // Input'un b�y�kl���n� hesapla
//            inputPower = new Vector2(horizontal, vertical).magnitude;

//            // Y�n hesaplama
//            if (inputPower > 0)
//            {
//                direction = Mathf.RoundToInt(Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg); // A��y� do�ru hesapla
//            }
//            else
//            {
//                direction = 0; // Hareket yoksa y�n� s�f�rla
//            }

//            velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);

//            // Animasyon g�ncellemeleri
//            anim.SetBool("isWalking", inputPower > 0);
//            anim.SetInteger("Direction", GetDirectionFromInput(horizontal, vertical));
//        }
//        else
//        {
//            velocity = Vector2.zero;  // Panel a��kken hareket duracak
//            anim.SetBool("isWalking", false); // Animasyonu durdur
//            anim.SetInteger("Direction", 0); // Y�n� s�f�rla
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
