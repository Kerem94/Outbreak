using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Kontroll_Script : MonoBehaviour
{
    public float z_zombie_geschwindigkeit;
    public float h_halt_position;
    public float r_rueckzug_position;
    public bool s_spieler_ist_da;
    public bool a_angriff;
    public Transform z_geht_richtung_spieler;
    public Collider2D z_zombie_blick;

   Animator z_zombie_animation;
    bool s_spieler_guckt_rechts;
   
    private Vector2 dir;


    // Start is called before the first frame update
    void Start()
    {
        z_zombie_blick.GetComponentInParent<Collider2D>();
        
        if (s_spieler_ist_da == true)
        {
            z_geht_richtung_spieler = GameObject.FindGameObjectWithTag("Player").transform;
        }
        z_zombie_animation = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (s_spieler_ist_da == true)
        {
            if (Vector2.Distance(transform.position, z_geht_richtung_spieler.position) > h_halt_position)
            {
                if (s_spieler_ist_da == true)
                {
                    transform.position = Vector2.MoveTowards(transform.position, z_geht_richtung_spieler.position, z_zombie_geschwindigkeit * Time.deltaTime);
                    z_zombie_animation.SetBool("isMove", true);
                    // print("zombie geht");
                }
                if (Spieler_Ist_Da.s_spieler_ist_weg == true && s_spieler_ist_da == false)
                {
                    z_zombie_animation.SetBool("isMove", false);
                }
            }
            else if (Vector2.Distance(transform.position, z_geht_richtung_spieler.position) < h_halt_position && Vector2.Distance(transform.position, z_geht_richtung_spieler.position) > r_rueckzug_position)
            {
                transform.position = this.transform.position;
                Flip();

            }
            else if (Vector2.Distance(transform.position, z_geht_richtung_spieler.position) < r_rueckzug_position)
            {
                transform.position = Vector2.MoveTowards(transform.position, z_geht_richtung_spieler.position, -z_zombie_geschwindigkeit * Time.deltaTime);
                Flip();
            }
        }
        if (s_spieler_ist_da == false)
        {
            z_zombie_animation.SetBool("isMove", false);
        }
    }

    void Flip()
    {
        //here your flip funktion, as example
        s_spieler_guckt_rechts = !s_spieler_guckt_rechts;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spieler_bauch"))
        {
            z_zombie_animation.SetBool("isAttack",true);
            z_zombie_animation.SetBool("isMove", true);
            //s_spieler_ist_da = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("spieler_bauch"))
        {
          //  z_zombie_animation.SetBool("isAttack", true);
            z_zombie_animation.SetBool("isMove", true);
            //s_spieler_ist_da = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("spieler_bauch"))
        {
            z_zombie_animation.SetBool("isAttack", false);
            z_zombie_animation.SetBool("isMove", false);
        }
    }
}
