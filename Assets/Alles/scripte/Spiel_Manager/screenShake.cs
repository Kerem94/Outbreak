using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShake : MonoBehaviour
{
  
    //  public Transform positionen;
    public Animator myanim;
    




    public void screenShake1()
    {
        myanim.SetTrigger("isShake");
    }
}
