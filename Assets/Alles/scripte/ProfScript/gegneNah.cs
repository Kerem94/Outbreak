using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gegneNah : MonoBehaviour
{
    Animator myAnim;
    public static bool nahkampf;
    public void Start()
    {
        myAnim = GetComponentInParent<Animator>();
    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spieler")
        {
            playerHealth theHealth = collision.gameObject.GetComponent<playerHealth>();
            theHealth.addDamage(10);
            //  myAnim.SetTrigger("isKampf");
            //playerHealth gegnerGetroffen = collision.gameObject.GetComponent<playerHealth>();
            //gegnerGetroffen.addDamage(10);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Spieler")
        {
        
         //   myAnim.SetTrigger("isKampf");
          //  playerHealth gegnerGetroffen = collision.gameObject.GetComponent<playerHealth>();
          //  gegnerGetroffen.addDamage(10);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Spieler")
        {
           
            //   myAnim.SetTrigger("isKampf");
            //  playerHealth gegnerGetroffen = collision.gameObject.GetComponent<playerHealth>();
            //  gegnerGetroffen.addDamage(10);

        }
    }
}
