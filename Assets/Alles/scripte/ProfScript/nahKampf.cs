using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nahKampf : MonoBehaviour
{
  
    //Das script für spieler bajonet 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "feindK")
        {

            enemyHealth gegnerGetroffen = collision.gameObject.GetComponentInParent<enemyHealth>();
            gegnerGetroffen.addDamage(10);
            print("feind getroffen");
        }
     
    }  
}
