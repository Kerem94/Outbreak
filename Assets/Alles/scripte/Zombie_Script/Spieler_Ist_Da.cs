using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler_Ist_Da : MonoBehaviour
{
    Zombie_Kontroll_Script zp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            zp = GameObject.FindObjectOfType(typeof(Zombie_Kontroll_Script)) as Zombie_Kontroll_Script;
            zp.s_spieler = true;
          
            print("spieler_da");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            zp = GameObject.FindObjectOfType(typeof(Zombie_Kontroll_Script)) as Zombie_Kontroll_Script;
            zp.s_spieler = true;
            print("spieler_da");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            zp = GameObject.FindObjectOfType(typeof(Zombie_Kontroll_Script)) as Zombie_Kontroll_Script;
            zp.s_spieler = false;
            print("spieler_ist_weg");
        }
    }
}
