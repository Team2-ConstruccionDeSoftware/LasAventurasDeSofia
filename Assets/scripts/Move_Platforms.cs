using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Platforms : MonoBehaviour
{
    [SerializeField] float vel;
    [SerializeField] float Limit;
    private Rigidbody2D rd;
    private SpriteRenderer sr;
    

    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        rd.velocity = new Vector2(0f, vel);
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //rd.velocity = new Vector2(vel, 0f);
       
        if(transform.position.y > Limit)
        {
            Destroy(this.gameObject);
        }
    }
}
