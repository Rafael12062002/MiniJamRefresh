using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
public class MovePlayer : MonoBehaviour
{
    public Player player;
    float input_x = 0;
    //float input_y = 0;
    public float speed = 2.5f;
    public bool isWalking = false;
    public float jumpForce = 10f;
    public bool isJump = false;
    public bool isRunning = false;
    private Animator animator;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    //Aqui usamos o velocity para fazer a movimentação do personagem usando o axes horizontal
    //Here we use velocity to move the character using the horizontal axis
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float movimento = Input.GetAxis("Horizontal");
        //input_y = input_y.GetAxisRaw("Vertical"); se eu quiser fazer no modelo top-down
        //input_y = input_y.GetAxisRaw("Vertical"); if I want to do it in the top-down model
        rb.velocity = new Vector2(movimento * speed, rb.velocity.y);

        if(Input.GetAxis("Horizontal") > 0f)
        {
            animator.SetBool("isRunning", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            animator.SetBool("isRunning", true);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            animator.SetBool("isRunning", true);
            transform.eulerAngles = new Vector3 (0f, 180f, 0f);
            animator.SetBool("isRunning", true);
        }
        if (Input.GetAxis("Horizontal") ==  0)
        {
            animator.SetBool("isRunning", false);
        }

    }

    //Metodo de pulo
    //Jump method
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isJump == false)
        {
            //Jumping...
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("isJuping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Chao") || collision.gameObject.CompareTag("Plataforma"))
        {
            isJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Chao") || collision.gameObject.CompareTag("Plataforma"))
        {
            isJump = true;
        }
    }
}
