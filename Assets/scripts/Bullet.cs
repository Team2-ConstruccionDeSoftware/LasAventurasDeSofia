using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float moveSpeed = 7f;

    Rigidbody2D rb;

    Vector2 moveDirection;  

    PlayerMovement target;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        target = GameObject.FindObjectOfType<PlayerMovement>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Sofia"))
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
        if (col.gameObject.tag.Equals("Tiles") || col.gameObject.tag.Equals("MovingPlat"))
        {
            Destroy(gameObject);
        }
    }
}
