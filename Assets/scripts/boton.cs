using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boton : MonoBehaviour
{
    //Cambiar desde el script el sprite
    public Sprite check;
    public Sprite cross;
    public Sprite pressed;
    public SpriteRenderer button;
    public bool correct = false;
    
    Collider2D colliderPlayer;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D colliderPlayer)
    {
        if(colliderPlayer.tag == "Sofia")
        {
            //Falta definir ans
            button.sprite = pressed;
            var ans = GetComponentsInChildren<SpriteRenderer>();
            //Debug.Log(ans[1].sprite);
            if(correct){
                ans[1].sprite = check;
            }
            else{
                ans[1].sprite = cross;
            }
        }
    }
}

