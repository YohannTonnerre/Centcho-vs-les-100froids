using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesAnimations : MonoBehaviour
{

    public Animator animator;
   
    void Update()
    {
     

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

    }
}
