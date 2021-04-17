using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField] float vel;
    [SerializeField] float initialPosition;
    [SerializeField] float finalPosition;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(vel, 0f);
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //cambia en 4,-4
        if(transform.position.x < initialPosition)
        {
            sr.flipX = true;
            rb.velocity = new Vector2(vel, 0f);
        }
        if(transform.position.x > finalPosition)
        {
            sr.flipX = false;
            rb.velocity = new Vector2(-vel, 0f);
        }
        
    }
}