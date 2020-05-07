using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{
    public float healthAmount;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth theHealth = collision.gameObject.GetComponent<playerHealth>();
            theHealth.addHealth(healthAmount);
            Destroy(gameObject);
        }
        if (collision.tag == "deutschesPanzer")
        {
         //   DeutschesPanzerLeben panzerLeben = collision.gameObject.GetComponent<DeutschesPanzerLeben>();
         //   panzerLeben.addHealth(20);
            Destroy(gameObject);
        }
    }
}
