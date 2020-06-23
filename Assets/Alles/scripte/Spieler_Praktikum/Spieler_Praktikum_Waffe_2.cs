using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spieler_Praktikum_Waffe_2 : MonoBehaviour
{
    public GameObject p_pistole;
    public GameObject f_feuer_effeckt;
    public GameObject p_projectile;
    public float offset;
    float r_rotZ;


    public Transform f_feuer_effeckt_position;
    public Transform s_schuss_position;


    private float t_time_btw_shots;
    public float s_start_time_btw_shots;


    // Update is called once per frame
    void Update()
    {
        // Handles the weapon rotation
        if (!IsPointerOverUIObject())
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            r_rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, r_rotZ + offset);

            if (t_time_btw_shots <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    Instantiate(p_projectile, s_schuss_position.position, transform.rotation);
                    Instantiate(f_feuer_effeckt, f_feuer_effeckt_position.position, transform.rotation);

                    //  SoundManagerScript.PlaySound("gewehr98");
                    t_time_btw_shots = s_start_time_btw_shots;
                    //  Spieler.waffe1Ammo--;
                    //  SoundManagerScript.PlaySound("waffeladen");
                }

            }
            else
            {
                t_time_btw_shots -= Time.deltaTime;

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
