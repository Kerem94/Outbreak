using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistolen_Animation_Kontroller_Klasse : MonoBehaviour
{
    public Animator p_pitole_animation;

    public void p_pistole()
    {
        p_pitole_animation.SetTrigger("isPistole");
    }
}
