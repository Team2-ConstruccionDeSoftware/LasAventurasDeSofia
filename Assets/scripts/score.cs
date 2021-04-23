using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour
{
    // Start is called before the first frame update
    public Text myScoreText;
    public int scoreNum;
    livesManager lives;
    void Start()
    {
        scoreNum = 1000;
        myScoreText.text = "Score: " + scoreNum;
    }

    void OnTriggerEnter2D(Collider2D colliderPlayer)
    {
        lives = GameObject.FindGameObjectWithTag("Sofia").GetComponent<livesManager>();
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
            SoundManagerScript.playSound("correct");
            scoreNum += 150;
            myScoreText.text = "Score: " + scoreNum;
            colliderPlayer.enabled = false;
        }
        if(colliderPlayer.tag == "incorrecto"){
            SoundManagerScript.playSound("incorrect");
            scoreNum -= 200;
            myScoreText.text = "Score: " + scoreNum;
            lives.substLive();
            colliderPlayer.enabled = false;
        }
        if(colliderPlayer.tag == "lose"){
            //myScoreText.text += "\n GAME OVER";
            Debug.Log("Detected");
            //Time.timeScale = 0;  
        }
        if(colliderPlayer.tag == "enemy"){
            scoreNum -= 100;
            myScoreText.text = "Score: " + scoreNum;
            SoundManagerScript.playSound("hit");
        }
        if (colliderPlayer.tag == "Bullet"){
            scoreNum -= 100;
            myScoreText.text = "Score: " + scoreNum;
            lives.substLive();
        }
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

