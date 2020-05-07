using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spieler_Praktikum_Waffe_1 : MonoBehaviour
{

    public GameObject gwaffe1Schuss;
    public GameObject muzzleEffeckt;
    public GameObject projectile;
    public float offset;
    float rotZ;


    public Transform muzzlePoint;
    public Transform shotPoint;


    private float timeBtwShots;
    public float startTimeBtwShots;
  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Handles the weapon rotation
        if (!IsPointerOverUIObject())
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                       Instantiate(projectile, shotPoint.position, transform.rotation);
                       Instantiate(muzzleEffeckt, muzzlePoint.position, transform.rotation);
              
                  //  SoundManagerScript.PlaySound("gewehr98");
                    timeBtwShots = startTimeBtwShots;
                  //  Spieler.waffe1Ammo--;
                  //  SoundManagerScript.PlaySound("waffeladen");
                }

            }
            else
            {
                timeBtwShots -= Time.deltaTime;

            }
            // Debug.Log("Not over gameobject");

        }
        else if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            // Debug.Log("over gameobject");
        }
    }


    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;

    }
}
