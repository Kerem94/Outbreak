﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler_Kontroll_Script : MonoBehaviour
{
    public GameObject Spieler_Leben_Slider;
    public GameObject Spieler_Shot_Gun_Arm;
    public GameObject Spieler_Pistolen_Arm;
    public GameObject Spieler_Base_Ball_Schlaeger_Arm;
    Spieler_Leben s_spieler_leben;
    private Animator m_spieler_animator_kontroll;
    private Rigidbody2D r_rigid_body_spieler;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private Base_Ball b_base_Ball_attack;
    private Vector2 moveVelocity;
    public float speed;
    //float move = 0f;
    bool r_gesichts_richtung;

    //jumping varible
    //private bool i_ist_aufem_boden = false;
    public float b_boden_radius_kontrolle = 0.4f;
    public LayerMask b_boden_layer_maske;
    public Transform t_transform_boden_check_objekt;
    public float s_sprug_hoehe;
    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        r_rigid_body_spieler = GetComponent<Rigidbody2D>();
        m_spieler_animator_kontroll = GetComponent<Animator>();
       // Spieler_Shot_Gun_Arm = GetComponentInChildren<GameObject>();
        Spieler_Shot_Gun_Arm.SetActive(false);
       // Spieler_Base_Ball_Schlaeger_Arm= GetComponentInChildren<GameObject>();
        Spieler_Base_Ball_Schlaeger_Arm.SetActive(true);
        //
        Spieler_Pistolen_Arm.SetActive(false);
        //
        r_gesichts_richtung = true;
       // b_base_Ball_attack  = GameObject.FindGameObjectWithTag("Animation_Kontroller_Baseball").GetComponent<Base_Ball>();
    }

    public void Update()
    {
      //  if (PlayerPrefs.GetInt("shot_gun_gekauf")==0&& PlayerPrefs.GetInt("shot_gun", 0) ==0&& WaffenKammer.shot_gun_gekauft == true)
      //  {
            if (Input.GetKey(KeyCode.Alpha1))
            {

                Spieler_Shot_Gun_Arm.SetActive(true);
                Spieler_Base_Ball_Schlaeger_Arm.SetActive(false);
                Spieler_Pistolen_Arm.SetActive(false);
        //    }
        }
       // if (PlayerPrefs.GetInt("pistole_gekauft", 1)==1 && PlayerPrefs.GetInt("pistole", 1) == 1 && WaffenKammer.pistole_gekauft==true)
       // {
            if (Input.GetKey(KeyCode.Alpha2))
            {

                Spieler_Shot_Gun_Arm.SetActive(false);
                Spieler_Base_Ball_Schlaeger_Arm.SetActive(false);
                Spieler_Pistolen_Arm.SetActive(true);
         //   }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        
           
        //Bewegeung Spieler
        float move = Input.GetAxis("Horizontal");

        m_spieler_animator_kontroll.SetFloat("speed", Mathf.Abs(move));

        r_rigid_body_spieler.velocity = new Vector2(move * speed, r_rigid_body_spieler.velocity.y);
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //b_base_Ball_attack.spieler_is_baseball();
            m_spieler_animator_kontroll.SetTrigger("isSchwung");
        }
        else
        {
            // m_spieler_animator_kontroll.SetTrigger("isIdle");
        }
      
        if (move > 0 && !r_gesichts_richtung)
        {

            flip();
        }
        else if (move < 0 && r_gesichts_richtung)
        {
            flip();
        }

    }
    public void flip()
    {
        r_gesichts_richtung = !r_gesichts_richtung;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
}
