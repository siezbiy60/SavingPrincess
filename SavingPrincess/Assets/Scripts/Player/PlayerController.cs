using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
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


    }
    private void FixedUpdate()
    {
       rb.velocity=velocity;

    }




}
