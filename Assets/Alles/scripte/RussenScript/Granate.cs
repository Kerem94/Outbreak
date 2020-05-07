using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granate : MonoBehaviour
{
    float timer = 1.8f;
    float countdown;
    bool hasExplodet;
    public GameObject explosion;
    public float damage;
    public float speed;
    public CircleCollider2D cd2;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        cd2 = GetComponent<CircleCollider2D>();
        cd2.enabled = false;
        cd2.isTrigger = false;
        countdown = timer;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExplodet){
           
            hasExplodet = true;
            if (hasExplodet == true)
            {
               
                cd2.enabled = true;
                cd2.isTrigger = true;
                Instantiate(explosion, transform.position, Quaternion.identity);
                SoundManagerScript.PlaySound("mine");
                Destroy(this.gameObject,0.1f);
            }
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            
            if (cd2.isTrigger = true && cd2.enabled == true)
            {
                collider.GetComponent<enemyHealth>().addDamage(damage);
              
                Destroy(this.gameObject);
            }
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 15||collision.gameObject.layer==17)
        {
            speed = 0;
        }
    }
}
