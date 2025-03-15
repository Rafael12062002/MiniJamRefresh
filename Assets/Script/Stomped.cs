using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomped : MonoBehaviour
{
    public float force;
    public bool stomp = false;

    public Rigidbody2D rbEnemy;
    void Start()
    {
        rbEnemy.isKinematic = true;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            playerRb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
            stomp = true;


            //desativar Box Collider do inimigo
            BoxCollider2D boxCollider = transform.parent.gameObject.GetComponent<BoxCollider2D>();
            boxCollider.enabled = false;
            rbEnemy.isKinematic = false;

            Destroy(transform.parent.gameObject, 2f);
        }
    }

    private void OnBecameInvisible()
    {
        if(stomp)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
