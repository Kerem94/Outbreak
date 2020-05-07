using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{
    public static bool facingRight;
    private Rigidbody2D rb;
     private Animator anim;
    public GameObject bauch;
    public static bool idleVerbot;
    //private Vector2 moveVelocity;
    public float speed;
    float dirX,dirY;
    [Range(1f, 20f)]
    public float moveSpeed;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       
        facingRight = true;
        speed = 10f;
    }

    private void Update()
    {
        // Getting move direction according to button pressed
        // multiplied by move speed and time passed
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        dirY = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Setting new transform position of game object
        transform.position = new Vector2(transform.position.x + dirX, transform.position.y + dirY);
    

        /*
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        moveVelocity = moveInput * speed;
       
        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRun", true);
          
         
        }
        else
        {
          
            Weapon.zielenErlaubt = true;
            anim.SetBool("isRun", false);
            //anim.SetBool("isIdle", true);
        }
    
        //Android Version
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * speed;
        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
        //Android ende
        if (!PlayerController.facingRight)
        {
            facingRight = !facingRight;
            Vector3 thescale = bauch.transform.localScale;
            thescale.x *= -1;
            bauch.transform.localScale = thescale;
            Weapon.mySpriteRenderer.flipY = false;
        }
       // transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 5, 0, 0);
       */

        if(Input.GetAxis("Horizontal")<0&&facingRight|| Input.GetAxis("Horizontal") > 0 && !facingRight)
        {
            
            facingRight = !facingRight;
            Vector3 thescale = bauch.transform.localScale;
            thescale.x *= -1;
            bauch.transform.localScale = thescale;
            
        }
    
    }
    
    private void FixedUpdate()
    {
       // rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    
}