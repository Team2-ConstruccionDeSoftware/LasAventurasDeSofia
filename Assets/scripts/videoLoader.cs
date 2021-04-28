using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoLoader : MonoBehaviour
{
    [SerializeField] VideoPlayer video;
    [SerializeField] string videoName = "start.mp4";
    // Start is called before the first frame update
    void Start()
    {   
        // videoPlayer.url = 
        video.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
        Debug.Log("SA PATH: " + Application.streamingAssetsPath);
    }
}

