using UnityEngine;
using System.Collections;

public class camarafollow: MonoBehaviour
{
    //Wenn spieler tod dan guck dead body
     public Transform leiche;
    //=========================
   
    public Transform target;
   // public Transform target_spiel_ende_panel;
    public float smoothing;
    Vector3 offset;

    float lowY;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position;
        lowY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Spieler_Leben.spieler_lebt ==true)
        {
            Vector3 targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
            if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
        if(Spieler_Leben.spieler_lebt == false)
        {
            Vector3 targetCamPos = leiche.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
            if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }


}