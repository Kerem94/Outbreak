using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class EP : MonoBehaviour
{
    public TextMeshProUGUI r_rang_anzeiger;
    public TextMeshProUGUI g_geld_anzeiger;
    static int s_spieler_level;
    public static int g_geld;
    public static float e_ep_bekommen;
    public Slider e_ep_slider;
    public float e_ep_voll;
    public static float a_aktuelle_ep_stand;
    // Start is called before the first frame update
    void Start()
    {
        e_ep_slider.maxValue = e_ep_voll;
        e_ep_slider.value = a_aktuelle_ep_stand;
        // aktuelleEPstand wird geladen
        a_aktuelle_ep_stand = PlayerPrefs.GetFloat("epStand");
    }

    // Update is called once per frame
    void Update()
    {
        //Level auf das gespeicherte wert setzen
        s_spieler_level= PlayerPrefs.GetInt("lvl"); 
        r_rang_anzeiger.text = "lvl  " + s_spieler_level;
        //=============================
       
        //Geld speichern
        g_geld = PlayerPrefs.GetInt("g_geld_1");
        g_geld_anzeiger.text = "$  " + g_geld.ToString();
        //=============================
        e_ep_slider.value = a_aktuelle_ep_stand;
     
        if (a_aktuelle_ep_stand >= e_ep_slider.maxValue)
        {
            a_aktuelle_ep_stand = 0;
            s_spieler_level += 1;
            //Level bekommt ein neues Wert
            PlayerPrefs.SetInt("lvl",s_spieler_level);
        }
    }

    public void addEP(float ep)
    {
        a_aktuelle_ep_stand += ep;
        // aktuelleEPstand wird gespeichert
        PlayerPrefs.SetFloat("epStand", a_aktuelle_ep_stand);
        if (a_aktuelle_ep_stand > e_ep_voll)
        {
           
            a_aktuelle_ep_stand = e_ep_voll;
            e_ep_slider.value = a_aktuelle_ep_stand;
            
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("g_geld_1"))
        {
            g_geld += 10;
            PlayerPrefs.SetInt("g_geld_1", g_geld);
            print("geld aufgehoben");
        }
    }

}
