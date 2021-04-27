using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoLoader : MonoBehaviour
{
    [SerializeField] VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {   
        // videoPlayer.url = 
        video.url = System.IO.Path.Combine(Application.streamingAssetsPath, "start.mp4");
        Debug.Log("SA PATH: " + Application.streamingAssetsPath);
    }
}

