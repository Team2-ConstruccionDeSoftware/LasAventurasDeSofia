  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goal : MonoBehaviour
{
    // Start is called before the first frame update
    public Text myScoreText;
    public GameObject gameManager;
    //public score scoreNum;
    void OnTriggerEnter2D(Collider2D coin)
    {
        if (coin.tag == "Sofia")
        {
            //Destroy(coin.gameObject);
            //Stop simulation
            //Time.timeScale = 0;
            gameObject.SetActive(false);  
            gameManager.GetComponent<levelSelector>().ButtonMoveScene("win");
        }
    }
}