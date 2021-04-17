using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "enemy")
        {
            Destroy(enemy.gameObject);
        }
    }
}
