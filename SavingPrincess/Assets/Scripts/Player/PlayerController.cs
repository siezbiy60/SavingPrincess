using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private bool canMove = true;  // Hareket kontrolü için deðiþken

    private float inputPower;

    public float moveSpeed;
    public int direction;
    public bool isWalking;

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 velocity;
    private float horizontal;
    private float vertical;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal=Input.GetAxis("Horizontal");
        vertical=Input.GetAxisRaw("Vertical");


        GetComponent<SpriteRenderer>().flipX=(horizontal < 0);


        inputPower = new Vector2(horizontal, vertical).magnitude;




        if (inputPower != 0)
            direction =Mathf.RoundToInt (Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg);


        velocity = new Vector2(horizontal*moveSpeed,vertical*moveSpeed);
        
       

        anim.SetBool("isWalking",(inputPower >0));
       anim.SetInteger("Direction",direction);

        if (canMove)
        {
            velocity.x = Input.GetAxisRaw("Horizontal");
            velocity.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            velocity = Vector2.zero;  // Panel açýkken hareket duracak
        }

    }
    private void FixedUpdate()
    {
       rb.velocity=velocity;
        GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + velocity * moveSpeed * Time.fixedDeltaTime);


    }

    public void EnableMovement()
    {
        canMove = true;
    }

    public void DisableMovement()
    {
        canMove = false;
    }


}
