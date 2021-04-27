using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class htmlConnection : MonoBehaviour
{
    [SerializeField] string playerId;
    public void getPlayerId(string playerIdFromWeb){
        PlayerPrefs.SetString("playerId", playerIdFromWeb);
        playerId = playerIdFromWeb;
        Debug.Log(playerId);
    }
}
