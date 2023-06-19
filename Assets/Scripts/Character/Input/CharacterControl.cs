using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float jumpForce = 14f;
    public Rigidbody2D rb;
    public bool isGrounded;

    private SpriteRenderer spriterenderer;

    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        Move(); //Постоянная проверка на передвижение

        if (Input.GetButtonDown("Jump") && isGrounded) //Проверка на нажатие прыжка
        {
            Jump();
        }

        Render();
    }

    private void FixedUpdate()
    {
       
    }

    void Jump() //Прыжок
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
    }

    void Move() //Передвижение 
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed,rb.velocity.y);
            animator.SetInteger("State",1);
        }
        else
            animator.SetInteger("State", -1);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void Render()
    {
        if (Input.GetAxisRaw("Horizontal")>0 )
        {
            spriterenderer.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spriterenderer.flipX = true;
        }
    }
}