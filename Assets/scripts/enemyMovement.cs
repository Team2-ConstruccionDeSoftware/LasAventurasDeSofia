using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField] float vel;
    public float desplazamiento = 1.5f;
    private float initialPosition;
    private float finalPosition;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 move;
    // Start is called before the first frame update
    private void Start()
    {
        initialPosition = transform.position.x - desplazamiento;
        finalPosition = transform.position.x + desplazamiento;
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(vel, 0f)
        move = new Vector2(vel, 0f);
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //cambia
        Debug.Log("entro al update" + move);
        transform.Translate(move*Time.fixedDeltaTime);
        if(transform.position.x < initialPosition)
        {
            sr.flipX = false;
            move.x = vel;
            //rb.velocity = new Vector2(vel, 0f);
        }
        if(transform.position.x > finalPosition)
        {
            sr.flipX = true;
            move.x = -vel;
            //rb.velocity = new Vector2(-vel, 0f);
        }
        
    }
}