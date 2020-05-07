using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Hauptmenu: MonoBehaviour
{
    public float s_start_zeit;
    public GameObject a_augen;
    private bool spiel_starten;
    
    void Start()
    {
        a_augen.SetActive(false);
    }

    void Update()
    {
        if (spiel_starten == true)
        {
            s_start_zeit-=Time.deltaTime;
            a_augen.SetActive(true);            
        }
        
        //Starte level wenn zeit unter null ist
        if (s_start_zeit < 0)
        {
            SceneManager.LoadScene("Level_1");
        }
    }

    public void level_1()
    {
        spiel_starten = true;
        SoundManagerScript.PlaySound("spiel_start_song");
    }

    public void spielende()
    {
        Application.Quit();
    }

  

  

}
