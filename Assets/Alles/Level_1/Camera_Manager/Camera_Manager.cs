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
}
