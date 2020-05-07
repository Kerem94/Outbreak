using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feinNahkampf : MonoBehaviour
{
    Animator myAnim;
    public bool spielerDa=false;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"||collision.tag=="deutschesGeschoss")
        {
            spielerDa = true;
            myAnim.SetBool("isIdle",false);
            myAnim.SetBool("isRun", false);
            myAnim.SetBool("isKampf", true);

        }
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            myAnim.SetBool("isIdle", false);
            myAnim.SetBool("isRun", false);
            myAnim.SetBool("isKampf", true);

        }
      
    }
}
