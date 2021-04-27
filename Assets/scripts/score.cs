using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    // Start is called before the first frame update
    public Text myScoreText;
    public int scoreNum;
    public int questionId;
    public GameObject preguntaId;
    livesManager lives;
    public int correctIncorrect;
    public GameObject api;
    public string path;
    void Start()
    {
        scoreNum = 1000;
        myScoreText.text = "Score: " + scoreNum;
    }
    public int getcorrectIncorrect(){
        return correctIncorrect;
    }
    public int getQuestionId(){
        return questionId;
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
            correctIncorrect = 1;
            //Guardar el path para identificar el player id en el readcsv
            GameObject boton  = colliderPlayer.gameObject;
            GameObject pregunta = boton.transform.parent.gameObject;
            var spriteR = pregunta.GetComponent<SpriteRenderer>();
            Debug.Log("AQUI ES " + spriteR.sprite.name);
            var path = "Assets/Q&A/" + spriteR.sprite.name;
            Debug.Log("funciona el path?");
            Debug.Log(path);
            questionId = preguntaId.GetComponent<readcsv>()
                                      .getIdPregunta(path);
            Debug.Log(questionId);
            //Start coroutine
            StartCoroutine(api.GetComponent<wwwFormGameData>().uploadData());
        }
        if(colliderPlayer.tag == "incorrecto"){
            SoundManagerScript.playSound("incorrect");
            scoreNum -= 200;
            myScoreText.text = "Score: " + scoreNum;
            lives.substLive();
            colliderPlayer.enabled = false;
            correctIncorrect = 0;
            //Guardar el path para identificar el player id en el readcsv
            GameObject boton  = colliderPlayer.gameObject;
            GameObject pregunta = boton.transform.parent.gameObject;
            var spriteR = pregunta.GetComponent<SpriteRenderer>();
            Debug.Log("AQUI ES " + spriteR.sprite.name);
            string path = "Assets/Q&A/" + spriteR.sprite.name;
            Debug.Log("funciona el path?");
            Debug.Log(path);
            questionId = preguntaId.GetComponent<readcsv>()
                                      .getIdPregunta(path);
            Debug.Log(questionId);
            //Start coroutine
            StartCoroutine(api.GetComponent<wwwFormGameData>().uploadData());
        }
       
        if(colliderPlayer.tag == "enemy"){
            SoundManagerScript.playSound("hit");
            scoreNum -= 100;
            myScoreText.text = "Score: " + scoreNum;
            colliderPlayer.enabled = false;
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

