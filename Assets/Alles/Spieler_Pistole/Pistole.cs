using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pistole : MonoBehaviour
{
    public GameObject f_faden_kreuz;
    public GameObject s_spieler;
    public GameObject g_geschoss_pre;
    public GameObject g_geschoss_start;
    //Neu========================

    

    //=================
    Animator a_animation;
    //=================
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float g_geschoss_geschwindigkeit = 60.0f;
    //=================================
    private Vector3 target;
    private Pistolen_Animation_Kontroller_Klasse p_pistolen_animation;
    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        a_animation = GetComponentInParent<Animator>();
        p_pistolen_animation = GameObject.FindGameObjectWithTag("Pistolen_Animation_Kontroller").GetComponent<Pistolen_Animation_Kontroller_Klasse>();
    }

    // Update is called once per frame
    void Update()
    {


        // Handles the weapon rotation
        if (!IsPointerOverUIObject())
        {
            target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            f_faden_kreuz.transform.position = new Vector2(target.x, target.y);

            Vector3 difference = target - s_spieler.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            s_spieler.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {


                    float distance = difference.magnitude;
                    Vector2 direction = difference / distance;
                    direction.Normalize();
                    fireBullet(direction, rotationZ);
               
                    timeBtwShots = startTimeBtwShots;
                    p_pistolen_animation.p_pistole();
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
        GameObject b = Instantiate(g_geschoss_pre) as GameObject;
        b.transform.position = g_geschoss_start.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * g_geschoss_geschwindigkeit;
        SoundManagerScript.PlaySound("shotgun_schuss");
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
