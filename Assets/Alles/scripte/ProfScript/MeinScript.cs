using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeinScript : MonoBehaviour
{
    public float enemySpeed;

    Animator enemyAnimator;
    //facing
    public GameObject enemyGraphic;

    bool facingRight = false;



    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
 
    }

    void flipFacing()
    {
  
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
        }
        else if (facingRight && collision.transform.position.x > transform.position.x)
        {
            flipFacing();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
         
        }
    }
}
