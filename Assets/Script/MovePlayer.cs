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

    Rigidbody2D rb;
    Vector2 movement = Vector2.zero;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimento = Input.GetAxis("Horizontal");
        //input_y = input_y.GetAxisRaw("Vertical"); se eu quiser fazer no modelo top-down
        rb.velocity = new Vector2(movimento * speed, rb.velocity.y);
        Jump();
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isJump == false)
        {
            Debug.Log("Pulando...");
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
