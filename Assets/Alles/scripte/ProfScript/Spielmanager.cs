using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Spielmanager : MonoBehaviour
{
    public Text zeit;
    public GameObject panel;
    public GameObject Stern1_Voll;
    public GameObject Stern2_Voll;
    public GameObject Stern3_Voll;
    public GameObject Stern1_Leer;
    public GameObject Stern2_Leer;
    public GameObject Stern3_Leer;
    // Start is called before the first frame update
    void Start()
    {
      
        panel.SetActive(false);

        Stern1_Voll.SetActive(false);
        Stern2_Voll.SetActive(false);
        Stern3_Voll.SetActive(false);
        Stern1_Leer.SetActive(false);
        Stern2_Leer.SetActive(false);
        Stern3_Leer.SetActive(false);
    }
 
   
    //Wenn mit werkzteug zurueck
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("werkzeugkasten"))
        {
            panel.SetActive(true);
            Time.timeScale = 0;
            /*
            if (Time.timeScale == 0)
            {
                
                if (CountdonwnTimer.spanTime.Minutes >= 4)
                Stern1_Voll.SetActive(true);
                Stern2_Voll.SetActive(true);
                Stern3_Voll.SetActive(true);
                zeit.text = "" + CountdonwnTimer.spanTime.Minutes + " : " + CountdonwnTimer.spanTime.Seconds;
                
            }else if (Time.timeScale == 0)
            {
                if (CountdonwnTimer.spanTime.Minutes >= 2)
                Stern1_Voll.SetActive(true);
                Stern2_Voll.SetActive(true);
                Stern3_Leer.SetActive(true);
                zeit.text = "" + CountdonwnTimer.spanTime.Minutes + " : " + CountdonwnTimer.spanTime.Seconds;
            }
            else if (Time.timeScale == 0)
            {
                if (CountdonwnTimer.spanTime.Minutes >=1)
                Stern1_Voll.SetActive(true);
                Stern2_Leer.SetActive(true);
                Stern3_Leer.SetActive(true);
                zeit.text = "" + CountdonwnTimer.spanTime.Minutes + " : " + CountdonwnTimer.spanTime.Seconds;

            }*/
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
      
    }
    private void OnTriggerExit2D(Collider2D other)
    {
       
    }
  

    public void Map0()
    {
        SceneManager.LoadScene("Map0");
        Time.timeScale = 1;
    }
    public void Map1()
    {
        SceneManager.LoadScene("Map1");
        Time.timeScale = 1;
    }
    public void hauptmenu()
    {
        SceneManager.LoadScene("Hauptmenu");
        Time.timeScale = 1;
    }
    public void spielende()
    {
        Application.Quit();
    }
    public void neustart()
    {
   //  CountdonwnTimer.countDownStartValue = 360;
       // Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }
}
