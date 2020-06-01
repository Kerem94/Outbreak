using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    public Animator myanim;

    public void spieler_is_laden()
    {
        myanim.SetTrigger("isLaden");
    }

    //===================
    public void z_zombie_getroffen()
    {
        myanim.SetTrigger("isHit");
        print("hit_animation");
    }
}
