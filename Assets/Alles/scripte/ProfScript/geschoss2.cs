using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geschoss2 : MonoBehaviour
{
    public float waffe2;
    public float geschossSpeed;
    Rigidbody2D myRb;
    // Start is called before the first frame update
    void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
            myRb.AddForce(new Vector2(-1, 0) * geschossSpeed, ForceMode2D.Impulse);
        else
            myRb.AddForce(new Vector2(1, 0) * geschossSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            if (other.tag == "Enemy")
            {
                enemyHealth gegnerGetroffen = other.gameObject.GetComponent<enemyHealth>();
               gegnerGetroffen.addDamage(10);
                Destroy(gameObject);
            }
        }
    }
}
