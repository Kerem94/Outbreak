using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WaffenKammer : MonoBehaviour
{
    public static int waffeWK1 =1;
    public static int waffeWK2 =2;
    public static int waffeWK3 =3;
    public void hauptmenu()
    {
        SceneManager.LoadScene("Hauptmenu");
    }

    public void waffe1()
    {
        //Spieler.waffe2 = false;
       // Spieler.waffe1 = true;
        print("waffe1 gewählt");
     
        PlayerPrefs.SetInt("waffe1", 1);
        //auf falsche werte setzen
        PlayerPrefs.SetInt("waffe2", 5);
        PlayerPrefs.SetInt("waffe3", 6);
        waffeWK1 = PlayerPrefs.GetInt("waffe1", 1);
    }
    public void waffe2()
    {
        //Spieler.waffe1 = false;
        //Spieler.waffe2 = true;
      
        PlayerPrefs.SetInt("waffe2", 2);
        //auf falsche werte setzen
        PlayerPrefs.SetInt("waffe1", 0);
        PlayerPrefs.SetInt("waffe3", 6);
        waffeWK2 = PlayerPrefs.GetInt("waffe2", 2);
        print("waffe2 gewählt");
    }
    public void waffe3()
    {
        //Spieler.waffe1 = false;
        //Spieler.waffe2 = true;
        PlayerPrefs.SetInt("waffe1", 0);
        PlayerPrefs.SetInt("waffe2", 5);
        PlayerPrefs.SetInt("waffe3", 3);
        waffeWK3 = PlayerPrefs.GetInt("waffe3", 3);
        print("granate gewählt");
    }
}
