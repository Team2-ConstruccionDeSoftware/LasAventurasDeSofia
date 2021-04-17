using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightAnimator : MonoBehaviour
{
    public Animator animator;
    public GameObject Classroom;
    void Update()
    {
        if(Input.GetButtonDown("Open"))
        {
            animator.SetBool("OpenDoor", true);
            Classroom.SetActive(true);
        }
        if(Input.GetButtonUp("Open"))
        {
            Classroom.SetActive(false);
        }
    }
}

