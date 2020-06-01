using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class EP : MonoBehaviour
{
    public TextMeshProUGUI levelUI;
    static int level;
    public static float epbekommen;
    public Slider ep_Slider;
    public float epVoll;
    public static float aktuelleEPstand;
    // Start is called before the first frame update
    void Start()
    {
        ep_Slider.maxValue = epVoll;
        ep_Slider.value = aktuelleEPstand;
        // aktuelleEPstand wird geladen
        aktuelleEPstand = PlayerPrefs.GetFloat("epStand");
    }

    // Update is called once per frame
    void Update()
    {
        //Level auf das gespeicherte wert setzen
        level= PlayerPrefs.GetInt("lvl"); 
        levelUI.text = "lvl  " + level;
        //=============================
         
         ep_Slider.value = aktuelleEPstand;
     
        if (aktuelleEPstand >= ep_Slider.maxValue)
        {
            aktuelleEPstand = 0;
            level += 1;
            //Level bekommt ein neues Wert
            PlayerPrefs.SetInt("lvl",level);
        }
    }

    public void addEP(float ep)
    {
        aktuelleEPstand += ep;
        // aktuelleEPstand wird gespeichert
        PlayerPrefs.SetFloat("epStand", aktuelleEPstand);
        if (aktuelleEPstand > epVoll)
        {
           
            aktuelleEPstand = epVoll;
            ep_Slider.value = aktuelleEPstand;
            
        }
    }

}
