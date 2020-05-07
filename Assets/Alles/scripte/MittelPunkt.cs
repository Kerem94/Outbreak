using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MittelPunkt : MonoBehaviour
{
  
    public bool mitte_british;
    public bool mitte_deutsch;
    void Start()
    {
        mitte_british = false;
        mitte_deutsch = false;
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("bm_trigger"))
        {
            
            mitte_british = true;
        }
        if (collision.CompareTag("dm_trigger"))
        {

            mitte_deutsch = true;
        }
    }


}
