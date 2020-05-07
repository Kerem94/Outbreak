using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject explode;
    public float damage;
    public float pushBackForce;
    public Transform boomPos;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth thePlayerHealth = collision.gameObject.GetComponent<playerHealth>();
            thePlayerHealth.addDamage(damage);
            SoundManagerScript.PlaySound("mine");
            Instantiate(explode, boomPos.position, Quaternion.identity);
            pushBack(collision.transform);
            Destroy(gameObject);
        }
        if (collision.tag == "deutschesPanzer")
        {
           // DeutschesPanzerLeben panzerLeben = collision.gameObject.GetComponent<DeutschesPanzerLeben>();
           // panzerLeben.addDamage(damage);
            SoundManagerScript.PlaySound("mine");
            Instantiate(explode, boomPos.position, Quaternion.identity);
            pushBack(collision.transform);
            Destroy(gameObject);
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
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "deuschesGeschoss")
        {
       
            SoundManagerScript.PlaySound("mine");
            Instantiate(explode, boomPos.position, Quaternion.identity);
            pushBack(collision.transform);
            Destroy(gameObject);
        }
    }
}
