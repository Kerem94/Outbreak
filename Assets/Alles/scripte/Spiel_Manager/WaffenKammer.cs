using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaffenKammer : MonoBehaviour
{
    public Button b_base_ball;
    public Button b_shot_gun;
    public Text b_shot_gun_text;
    public Button p_pistole;
    public Text p_pistolen_text;
    public Text g_geld_anzeiger_text;
    public static bool shot_gun_gekauft;
    public static bool pistole_gekauft;
    public static bool base_ball_update;

    public void Start()
    {
        b_base_ball.interactable = true;
        b_shot_gun.interactable  = true;
        p_pistole.interactable   = true;
    }

    public void Update()
    {
        g_geld_anzeiger_text.GetComponent<Text>().text = g_geld_anzeiger_text.text = "$ "+PlayerPrefs.GetInt("g_geld_1").ToString();

        if (PlayerPrefs.GetInt("shot_gun", 0) == 0&&shot_gun_gekauft==true)
        {
            b_shot_gun.interactable = false;
            b_shot_gun_text.GetComponent<Text>().text = b_shot_gun_text.text = "sold";
        }
        if (PlayerPrefs.GetInt("pistole_gekauft", 1) == 1 && pistole_gekauft == true)
        {
            p_pistole.interactable = false;
            p_pistolen_text.GetComponent<Text>().text = p_pistolen_text.text = "sold";
        }
        if (EP.g_geld < 10)
        {
            b_shot_gun.interactable = false;
            
        }
        if (EP.g_geld < 5)
        {
            p_pistole.interactable = false;
           
        }
        if (EP.g_geld < 5)
        {
            b_base_ball.interactable = false;
        }
    }

    public void shot_gun()
    {
        if (EP.g_geld > 10)
        {
            PlayerPrefs.SetInt("shot_gun",0);
            PlayerPrefs.SetInt("shot_gun_gekauf", 0);
            shot_gun_gekauft = true;
            b_shot_gun.interactable = false;
            EP.g_geld -= 10;
            PlayerPrefs.SetInt("g_geld_1",EP.g_geld);
            print("shotgun erfolgreich gekauft");
            b_shot_gun_text.GetComponent<Text>().text = b_shot_gun_text.text = "sold";
        }
    }
    public void pistole()
    {
        if (EP.g_geld > 5)
        {
            PlayerPrefs.SetInt("pistole", 1);
            PlayerPrefs.SetInt("pistole_gekauft", 1);
            pistole_gekauft = true;
            EP.g_geld -= 5;
            PlayerPrefs.SetInt("g_geld_1",EP.g_geld);
            p_pistolen_text.GetComponent<Text>().text = p_pistolen_text.text = "sold";
            print("pistole erfolgreich gekauft");
        }
    }
    public void base_ball_schlaeger()
    {
        if (EP.g_geld > 5)
        {
            EP.g_geld -= 5;
            PlayerPrefs.SetInt("g_geld_1",EP.g_geld);
            print("base_ball_schlaeger_update erfolgreich ");
        }
    }
    public void hauptmenu()
    {
        SceneManager.LoadScene("Hauptmenu");
    }
}
