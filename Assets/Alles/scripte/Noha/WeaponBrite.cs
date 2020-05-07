using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class WeaponBrite : MonoBehaviour
{

    public GameObject gwaffe1Schuss;

    public float offset;
    public GameObject projectile;

    public Transform shotPoint;
    public Transform panzerPosition;
    float rotZ;
    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Start()
    {
        panzerPosition = GameObject.FindGameObjectWithTag("deutschesPanzer").transform;
    }
    private void Update()
    {

            if (timeBtwShots <= 0 )
            {
               
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                    SoundManagerScript.PlaySound("gewehr98");
                    timeBtwShots = startTimeBtwShots;

                    SoundManagerScript.PlaySound("waffeladen");
            }
            else
            {
                timeBtwShots -= Time.deltaTime;

            }
    } 
}
