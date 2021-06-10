using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField] Animator anim;
    void Update()
    {
        ChangeAnimation();
    }
    
    void ChangeAnimation()
    {
        if(PlayerPrefs.GetFloat("Health") < 10)
        {
            anim.SetBool("Sick", true);
            anim.SetBool("Sad", false);
            anim.SetBool("Hungry", false);
        }
        if(PlayerPrefs.GetFloat("Energy") < 10)
        {
            anim.SetBool("Sad", true);
            anim.SetBool("Sick", false);
            anim.SetBool("Hungry", false);
        }
        if(PlayerPrefs.GetFloat("Hunger") < 10)
        {
            anim.SetBool("Hungry", true);
            anim.SetBool("Sick", false);
            anim.SetBool("Sad", false);
        }
        anim.SetBool("Sick", false);
        anim.SetBool("Sad", false);
        anim.SetBool("Hungry", false);

    }
}
