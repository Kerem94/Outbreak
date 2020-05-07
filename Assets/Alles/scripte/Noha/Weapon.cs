using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Weapon : MonoBehaviour
{
    Animator anim;
    public GameObject gwaffe1Schuss;
    public GameObject gwaffe2Schuss;
    public GameObject gwaffe3Schuss;
    //===============================
    public float offset;

    public GameObject projectile;
    public GameObject granate;
    public GameObject muzzleEffeckt;
    public Transform shotPoint;
    public Transform muzzlePoint;

    public float rotZ;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float startTimeBtwShots2;
    public float startTimeBtwShots3;
    void Start()
    {
        anim = GetComponentInParent<Animator>();

    if(PlayerPrefs.GetInt("waffe1", 1) == 1)
        {
            gwaffe1Schuss.SetActive(true);
        }
        else
        {
            gwaffe1Schuss.SetActive(false);
        }
        if (PlayerPrefs.GetInt("waffe2", 2) == 2)
        {
            gwaffe2Schuss.SetActive(true);
        }
        else
        {
            gwaffe2Schuss.SetActive(false);
        }
        if (PlayerPrefs.GetInt("waffe3", 3) == 3)
        {
            gwaffe3Schuss.SetActive(true);
        }
        else
        {
            gwaffe3Schuss.SetActive(false);
        }
    }
    private void Update()
    {
        
        // Handles the weapon rotation
        if (!IsPointerOverUIObject())
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            if (timeBtwShots <= 0 && PlayerPrefs.GetInt("waffe1", 1) == 1&&Spieler.waffe1Ammo>0)
            {
                if (Input.GetMouseButton(0))
                {
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                    Instantiate(muzzleEffeckt, muzzlePoint.position, transform.rotation);
                 
                    SoundManagerScript.PlaySound("gewehr98");
                    timeBtwShots = startTimeBtwShots;
                    Spieler.waffe1Ammo--;
                    SoundManagerScript.PlaySound("waffeladen");
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
        // Handles the weapon rotation
        if (!IsPointerOverUIObject())
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            if (timeBtwShots <= 0 && PlayerPrefs.GetInt("waffe2", 2) == 2&&Spieler.waffe2Ammo>0)
            {
                if (Input.GetMouseButton(0))
                {
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                    Instantiate(muzzleEffeckt, muzzlePoint.position, transform.rotation);

                    timeBtwShots = startTimeBtwShots2;
                    SoundManagerScript.PlaySound("waffe2");
                    Spieler.waffe2Ammo--;
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
            //  Debug.Log("over gameobject");
        }
        
        if (!IsPointerOverUIObject())
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            if (timeBtwShots <= 0 && PlayerPrefs.GetInt("waffe3", 3) == 3 && Spieler.waffe3Ammo>0)
            {
                if (Input.GetMouseButton(0))
                {
                   
                    Instantiate(granate, shotPoint.position, transform.rotation);
                    timeBtwShots = startTimeBtwShots3;
                    Spieler.waffe3Ammo--;
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
            //  Debug.Log("over gameobject");
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
