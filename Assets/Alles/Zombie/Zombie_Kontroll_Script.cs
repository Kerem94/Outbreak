using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Kontroll_Script : MonoBehaviour
{
    public float s_speed;
    public float h_halt_position;
    public float r_rueckzug_position;
    public bool s_spieler;
    bool facingRight;
    public Transform spieler;
    Animator myanim;
    private Vector2 dir;


    // Start is called before the first frame update
    void Start()
    {
     
       
        if (s_spieler == true)
        {
            spieler = GameObject.FindGameObjectWithTag("Player").transform;
        }
        myanim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (s_spieler == true)
        {
            if (Vector2.Distance(transform.position, spieler.position) > h_halt_position)
            {
                if (s_spieler == true)
                {
                    transform.position = Vector2.MoveTowards(transform.position, spieler.position, s_speed * Time.deltaTime);
                    myanim.SetBool("isMove", true);
                    // print("zombie geht");
                }
            }
            else if (Vector2.Distance(transform.position, spieler.position) < h_halt_position && Vector2.Distance(transform.position, spieler.position) > r_rueckzug_position)
            {
                transform.position = this.transform.position;
                Flip();

            }
            else if (Vector2.Distance(transform.position, spieler.position) < r_rueckzug_position)
            {
                transform.position = Vector2.MoveTowards(transform.position, spieler.position, -s_speed * Time.deltaTime);

            }
        }
        if (s_speed < 0)
        {
            myanim.SetBool("isMove", false);
        }
        if (playerHealth.spieler_lebt==false)
        {
            myanim.SetBool("isAttack", false);
        }
    }

    void Flip()
    {
        //here your flip funktion, as example
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spieler_bauch"))
        {
            myanim.SetBool("isAttack",true);

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("spieler_bauch"))
        {
            myanim.SetBool("isAttack", true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("spieler_bauch"))
        {
            myanim.SetBool("isAttack", false);
        }
    }
}
