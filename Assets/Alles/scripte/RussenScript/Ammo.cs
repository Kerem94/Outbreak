using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Spieler.waffe1Ammo += 5;
            Spieler.waffe2Ammo += 100;
            Spieler.waffe3Ammo += 3;
        }
     
    }


}
