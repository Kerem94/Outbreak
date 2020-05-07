using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Timer : MonoBehaviour
{
    /*
    public Button los;
    GameControll gmc;
    private float timeRemaining;
    private const float timerMax = 10f;
    public Slider spawnSlider;

  
    // Start is called before the first frame update
    void Start()
    {
      
        spawnSlider.value = 100;
        
        gmc = GameObject.FindObjectOfType(typeof(GameControll)) as GameControll;
      
    }

    // Update is called once per frame
    void Update()
    {
     
            spawnSlider.value = CalculateSliderValue();
            //wenn soldaten nachschub true dann funktuniere
            if (gmc.soldaten_nachschub == true)
            {
                timeRemaining = timerMax;
           
           }
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                //Wenn Null dann button wieder true
                los.interactable = true;

            }
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                //Bis null auf false setzen
                gmc.soldaten_nachschub = false;
                los.interactable = false;
           
            }
            
    }

    public float CalculateSliderValue()
    {
        return (timeRemaining / timerMax);
    }
    */
}
