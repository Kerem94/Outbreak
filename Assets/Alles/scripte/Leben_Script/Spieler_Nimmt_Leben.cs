using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler_Nimmt_Leben : MonoBehaviour
{
    public float s_spieler_bekommt_leben;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Spieler_Leben s_spieler_leben = collision.gameObject.GetComponent<Spieler_Leben>();
            s_spieler_leben.addHealth(s_spieler_bekommt_leben);
            Destroy(gameObject);
        }
       
    }
}
