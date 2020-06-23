using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler_Ist_Da : MonoBehaviour
{
    Zombie_Kontroll_Script zp;
    public static bool s_spieler_ist_weg;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")||collision.CompareTag("geschoss"))
        {
            zp = GameObject.FindObjectOfType(typeof(Zombie_Kontroll_Script)) as Zombie_Kontroll_Script;
            zp.s_spieler_ist_da = true;
          
            print("spieler_da");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")||collision.CompareTag("geschoss"))
        {
            zp = GameObject.FindObjectOfType(typeof(Zombie_Kontroll_Script)) as Zombie_Kontroll_Script;
            zp.s_spieler_ist_da = true;
            print("spieler_da");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            zp = GameObject.FindObjectOfType(typeof(Zombie_Kontroll_Script)) as Zombie_Kontroll_Script;
            zp.s_spieler_ist_da = false;
            s_spieler_ist_weg = true;
            print("spieler_ist_weg");
        }
    }
}
