using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip correct, incorrect, hit, lose;
    static AudioSource audioSrc;
    void Start()
    {
        correct = Resources.Load<AudioClip>("correct");
        incorrect = Resources.Load<AudioClip>("incorrect");
        hit = Resources.Load<AudioClip>("hit");
        lose = Resources.Load<AudioClip>("lose");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void playSound(string clip)
    {
        switch(clip)
        {
            case "correct":
                audioSrc.PlayOneShot(correct);
                break;
            case "incorrect":
                audioSrc.PlayOneShot(incorrect);
                break;
            case "hit":
                audioSrc.PlayOneShot(hit);
                break;
            case "lose":
                audioSrc.PlayOneShot(lose);
                break;  
        }
    }
}
