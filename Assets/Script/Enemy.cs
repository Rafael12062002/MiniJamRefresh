using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float distance;

    bool isRigth = true;
    public Transform groundCheck;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);

        if(ground.collider == false)
        {
            if(isRigth == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRigth = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isRigth = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bala"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
