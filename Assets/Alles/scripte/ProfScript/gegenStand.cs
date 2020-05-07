using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gegenStand : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "stacheldraht")
        {

            gegenStandLeben gegnerGetroffen = collision.gameObject.GetComponentInParent<gegenStandLeben>();
            gegnerGetroffen.addDamage(10);
            SoundManagerScript.PlaySound("stachel");
            print("feind getroffen");
        }
        if (collision.tag == "Dtarget1")
        {

            gegenStandLeben gegnerGetroffen = collision.gameObject.GetComponentInParent<gegenStandLeben>();
            gegnerGetroffen.addDamage(100);
            SoundManagerScript.PlaySound("stachel");
            print("feind getroffen");
        }
    }
}
