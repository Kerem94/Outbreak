using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour
{
    public float enemySpeed;

    Animator enemyAnimator;
    //facing
    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 5f;
    float nextFlipChance = 0f;

    //attacking
    public float angriffZeit;
    float startAngriffZeit;
  //  bool angriff;
    Rigidbody2D enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFlipChance)
        {
            if (Random.Range(0, 10) >= 0) flipFacing();
            nextFlipChance = Time.time + flipTime;        }
    }
    void flipFacing()
    {
        if (!canFlip) return;
        float facingX = enemyGraphic.transform.localScale.x;
        facingX *= -1f;
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!facingRight && collision.transform.position.x < transform.position.x)
               flipFacing();
        }else if(!facingRight &&collision.transform.position.x > transform.position.x)
        {
            flipFacing();
        }
        canFlip = false;
        //angriff = true;
        startAngriffZeit = Time.time + angriffZeit;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (startAngriffZeit < Time.time)
            {
                if (!facingRight) enemyRb.AddForce(new Vector2(-1, 0) * enemySpeed);
                else enemyRb.AddForce(new Vector2(1, 0) * enemySpeed);
              //  enemyAnimator.SetBool("isRun", angriff);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canFlip = true;
        //    angriff = false;
            enemyRb.velocity = new Vector2(0f, 0f);
          //  enemyAnimator.SetBool("isRun", false);
        }
    }
}
