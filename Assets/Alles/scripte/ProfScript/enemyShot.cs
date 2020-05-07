using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShot : MonoBehaviour
{
    Animator myAnim;
    public float speed;
    public float stoppngDistance;
    public float retreatDistance;
    public Transform schussPos;
    private float timeBtwShoots;
    public float startTimeBtwShots;
    public GameObject projectile;
    public Transform player;
    //MeinScript
    public GameObject enemyGraphic;
    bool facingRight = false;


    // Start is called before the first frame update
    void Start()
    {

        myAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < gameObject.transform.position.x && facingRight)
            Flip();
        if (player.transform.position.x > gameObject.transform.position.x && !facingRight)
            Flip();
        /*
        if (Vector2.Distance(transform.position, player.position) > stoppngDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            //  myAnim.SetTrigger("isRun");

        }

        else if (Vector2.Distance(transform.position, player.position) < stoppngDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
            //   myAnim.SetTrigger("isRun");

        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            //   myAnim.SetTrigger("isRun");

        }
        */
        if (timeBtwShoots <= 0)
        {
            myAnim.SetTrigger("isAttack");
            Instantiate(projectile, schussPos.position, Quaternion.identity);
            SoundManagerScript.PlaySound("gewehr98");
            timeBtwShoots = startTimeBtwShots;
            SoundManagerScript.PlaySound("waffeladen");
        } else
        {
            timeBtwShoots -= Time.deltaTime;
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
}
