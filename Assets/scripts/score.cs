using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour
{
    // Start is called before the first frame update
    public Text myScoreText;
    public int scoreNum;
    
    void Start()
    {
        scoreNum = 1000;
        myScoreText.text = "Score: " + scoreNum;
    }

    void OnTriggerEnter2D(Collider2D colliderPlayer)
    {
        if(colliderPlayer.tag == "coin"){
            if(scoreNum == 1000){
                myScoreText.text += "\n You win: Perfect!";
            }
            else if(scoreNum >= 700 && scoreNum<1000){
                myScoreText.text += "\n You win: Nice!";
            }
            else if (scoreNum > 500 && scoreNum<700){
                myScoreText.text += "\n You win: ok";
            }
            else if (scoreNum <= 500){
                myScoreText.text += "\n You can do better";
            }
        }
        //Como hacer para que no cuentele puntuacion cunado vuelvas a caer
        if(colliderPlayer.tag == "correcto"){
            scoreNum += 150;
            myScoreText.text = "Score: " + scoreNum;
            colliderPlayer.enabled = false;
        }
        if(colliderPlayer.tag == "incorrecto" && scoreNum>0){
            scoreNum -= 200;
            myScoreText.text = "Score: " + scoreNum;
            colliderPlayer.enabled = false;
        }
        if(colliderPlayer.tag == "lose"){
            myScoreText.text += "\n You lose";
            Debug.Log("Detected");
            Time.timeScale = 0;  
        }
        /*if(colliderPlayer.tag == "enemy"){
            scoreNum -= 100;
            myScoreText.text = "Score: " + scoreNum;
        }*/
    }

    /*void Update(){
        if(scoreNum > 0){
            ApplyScoreChanges();
        }
    }
    IEnumerator ApplyScoreChanges(){
        yield return new WaitForSeconds(1.0f);
        scoreNum = scoreNum - 1;
    }*/
}

