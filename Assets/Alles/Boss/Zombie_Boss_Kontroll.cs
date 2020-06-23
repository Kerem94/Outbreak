using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Boss_Kontroll : MonoBehaviour
{
   private float timeBtwDamage = 1.5f;
    public int b_boss_angriff;
    public bool s_spieler_lebt;

   // public Animator camAnim;

    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        /*
        if (health <= 25)
        {
            anim.SetTrigger("stageTwo");
        }

        if (health <= 0)
        {
            anim.SetTrigger("death");
        }

        // give the player some time to recover before taking more damage !
        if (timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }
        */

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // deal the player damage ! 
        if (other.CompareTag("Player") && s_spieler_lebt == false)
        {
            if (timeBtwDamage <= 0)
            {
               // camAnim.SetTrigger("shake");
                other.GetComponent<Spieler_Leben>().addDamage(b_boss_angriff);
            }
        }
    }
}
