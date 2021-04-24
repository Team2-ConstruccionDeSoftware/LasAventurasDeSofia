using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollider : MonoBehaviour
{
    GameObject pregunta;
    [SerializeField] GameObject qMark;
    SpriteRenderer qMarkSr;
    public Sprite dead;
    
    void Start(){
        qMarkSr = qMark.GetComponent<SpriteRenderer>();
        qMarkSr.enabled = true;
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Sofia")
        {
            var sr = GetComponent<SpriteRenderer>();
            sr.sprite = dead;
            Invoke("activate", 0.5f);
        }
    }
    void activate(){
        gameObject.SetActive(false);
        pregunta.SetActive(true);
        qMarkSr.enabled = false;
    }
    public void delayDeactivate(){
        Invoke("deactivate", 1f);
    }
    void deactivate(){
        pregunta.SetActive(false);
    }
    void Update(){
        if(pregunta == null){
            pregunta = qMark.transform.GetChild(0).gameObject;
            pregunta.SetActive(false);
        }
    }
}