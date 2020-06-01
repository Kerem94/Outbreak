using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointAndShoot : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    //Neu========================
    public GameObject muzzle_pre_frab;
    public GameObject muzzle_start;
    public static bool laden;

    //=================
    Animator a_animation;
    //=================
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float bulletSpeed = 60.0f;
    //=================================
    private Vector3 target;
    private Camera_Manager cm;
    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        a_animation = GetComponentInParent<Animator>();
        cm = GameObject.FindGameObjectWithTag("Animation_Kontroller_Spieler").GetComponent<Camera_Manager>();
    }

    // Update is called once per frame
    void Update()
    {


        // Handles the weapon rotation
        if (!IsPointerOverUIObject())
        {
            target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            crosshairs.transform.position = new Vector2(target.x, target.y);

            Vector3 difference = target - player.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {


                    float distance = difference.magnitude;
                    Vector2 direction = difference / distance;
                    direction.Normalize();
                    fireBullet(direction, rotationZ);
                    muzzel(direction, rotationZ);
                    timeBtwShots = startTimeBtwShots;
                    //laden = true;
                    // a_animation.SetTrigger("isLaden");
                    cm.spieler_is_laden();
                    SoundManagerScript.PlaySound("shotgun_laden");
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
    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        SoundManagerScript.PlaySound("shotgun_schuss");
    }
    void muzzel(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(muzzle_pre_frab) as GameObject;
        b.transform.position = muzzle_start.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * 1;
       
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