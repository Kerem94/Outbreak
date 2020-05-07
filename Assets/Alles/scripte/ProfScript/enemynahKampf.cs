using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemynahKampf : MonoBehaviour
{
    Animator myAnim;
    public float speed;
    public float stoppngDistance;
    public float retreatDistance;
      private Transform player;
    //MeinScript
    public GameObject enemyGraphic;
    bool facingRight = false;
    bool spielerDa=false;
   
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
   
      //      player = GameObject.FindGameObjectWithTag("Player").transform;
      

            player = GameObject.FindGameObjectWithTag("Player").transform;
        
     

    }

    // Update is called once per frame
    void Update()
    {
        //Facing richtung!
        if (player.transform.position.x < gameObject.transform.position.x && facingRight)
            Flip();
        if (player.transform.position.x > gameObject.transform.position.x && !facingRight)
            Flip();
        //====================================================================================
        if (spielerDa == true)
        {
          
            if (Vector2.Distance(transform.position, player.position) > stoppngDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                myAnim.SetBool("isRun",spielerDa);
             
            }
     
            else if (Vector2.Distance(transform.position, player.position) < stoppngDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
                myAnim.SetBool("isRun",spielerDa);

            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                myAnim.SetBool("isRun",spielerDa);

            }

          
        }
        else
        {
            spielerDa = false;
            myAnim.SetBool("isIdle",true);
            speed = 7;
        }
        if (spielerDa == false)
        {
            myAnim.SetBool("isIdle", true);
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
        
        if (collision.tag == "Player"||collision.CompareTag("deutschesGeschoss"))
        {
            spielerDa = true;
            // myAnim.SetTrigger("isKampf");
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player" || collision.CompareTag("deutschesGeschoss"))
        {
            spielerDa = true;
            // myAnim.SetTrigger("isKampf");
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
        private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spielerDa = false;
         
        }
    }
}
