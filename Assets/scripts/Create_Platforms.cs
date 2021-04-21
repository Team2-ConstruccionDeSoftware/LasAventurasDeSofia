using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Platforms : MonoBehaviour
{
    [SerializeField] GameObject Platform;
    [SerializeField] Vector2 limits;
    [SerializeField] float delay;
    
    public float numberPlats = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NewPlat", 1, delay);
    }

    // Update is called once per frame
    void NewPlat()
    {
        Instantiate(Platform, transform.position, Quaternion.identity);
    }
}
