using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cameraOne;
    public GameObject cameraTwo;

          int cameraPositionCounter;
 
    // Use this for initialization
    void Start()
    {
   
        cameraPositionCounter = Spieler.camera2;


        //Camera Position Set
        //cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update()
    {
        cameraPositionCounter = Spieler.camera2;

        //Change Camera Keyboard
        switchCamera();
        cameraChangeCounter();
    }

    //UI JoyStick Method
    public void cameraPositonM()
    {
        cameraChangeCounter();
    }

    //Change Camera Keyboard
    public void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            cameraChangeCounter();
        }
    }

    //Camera Counter
    public void cameraChangeCounter()
    {
  
           // PlayerPrefs.GetInt("CameraPosition");
       // cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    //Camera change Logic
   public void cameraPositionChange(int camPosition)
    {
        if (camPosition > 1)
        {
            camPosition = 0;
        }

        //Set camera position database
        //PlayerPrefs.SetInt("CameraPosition", camPosition);

        //Set camera position 1
        if (camPosition == 0)
        {
            cameraOne.SetActive(true);
      
            cameraTwo.SetActive(false);
        }

        //Set camera position 2
        if (camPosition == 1)
        {
            cameraTwo.SetActive(true);

            cameraOne.SetActive(false);
        }

    }
}
