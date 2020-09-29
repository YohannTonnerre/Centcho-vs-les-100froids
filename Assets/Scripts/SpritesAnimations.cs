using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesAnimations : MonoBehaviour
{

    public Animator animator;
   
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
    }
}
