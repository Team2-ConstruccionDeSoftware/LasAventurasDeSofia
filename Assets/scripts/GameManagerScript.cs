using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public void endGame(){
        //FindObjectOfType<GameManager>().endGame();
        if(gameHasEnded == false){
            Debug.Log("entramos");
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("restart", restartDelay);
        }
    }
    void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
