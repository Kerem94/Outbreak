using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ep_pickup : MonoBehaviour
{
    public float epPunkt;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EP erfahrung = collision.gameObject.GetComponent<EP>();
            erfahrung.addEP(epPunkt);
            Destroy(gameObject);
        }
    }
}
