using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Angriff : MonoBehaviour
{
    playerHealth ph;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spieler_bauch"))
        {
            ph = GameObject.FindObjectOfType(typeof(playerHealth)) as playerHealth;
            ph.addDamage(3);
           
        }
    }
    /*
    public float damage;
    public float damageRate;
    public float pushBackForce;

    float nextDamage;
    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && nextDamage < Time.time)
        {
            playerHealth thePlayerHealth = collision.gameObject.GetComponent<playerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(collision.transform);
        }
    }
    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, pushedObject.position.y - transform.position.y).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
    */
}
