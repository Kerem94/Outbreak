using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    public Animator a_animation;

    public void spieler_is_laden()
    {
        a_animation.SetTrigger("isLaden");
    }

    //===================
    public void z_zombie_getroffen()
    {
        a_animation.SetTrigger("isHit");
        print("hit_animation");
    }

    
}
