using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerGeschoss : MonoBehaviour
{


    public float lifeTime;
    public float distance;
    public int damage=10;
    public LayerMask whatIsSolid;
    public float pushBackForce;
    //public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("enemy"))
            {
                hitInfo.collider.GetComponent<enemyHealth>().addDamage(damage);
                print("enemy getroffen");
            }
            DestroyProjectile();
        }


      //  transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
     //   Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("shootable"))
        {
            if (other.tag == "enemy")
            {
                enemyHealth gegnerGetroffen = other.gameObject.GetComponent<enemyHealth>();
                gegnerGetroffen.addDamage(10);
    //            pushBack(other.transform);
                print("feind getroffen");
                Destroy(gameObject);
            }
        }
    }
    
    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, pushedObject.position.x - transform.position.x).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
       
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
