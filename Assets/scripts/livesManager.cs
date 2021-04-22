using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livesManager : MonoBehaviour
{
    public static int Lives = 3;
    public Vector2 SpawnPoint;
    public GameObject[] hearts;
    public Animator animator;
    void OnTriggerEnter2D (Collider2D col)
    {
        if(Lives>1){
            SpawnPoint = new Vector2(-20.32f, -5.61f);
        }
        else{
            SpawnPoint = new Vector2(-20.32f, -8.19f);
        }
        if (col.transform.tag == "lose"){
            Lives--;
            gameObject.transform.position = SpawnPoint;
        }
    }
    public void substLive(){
        Lives--;
    }
    void endGame(){
        Time.timeScale = 0;
    }
    //Perder vidas
    void Update(){
        if(Lives < 1){ //0
            Destroy(hearts[0].gameObject);
            //gameObject.transform.position = SpawnPoint;
            SoundManagerScript.playSound("lose");
            animator.SetBool("dies", true);
            Invoke("endGame", 2);
            //Sacar escena de game over con opcion de restart
        } else if(Lives < 2){ //1
            Destroy(hearts[1].gameObject);
        } else if(Lives < 3){ //2
            Destroy(hearts[2].gameObject);
        }
    }
}
