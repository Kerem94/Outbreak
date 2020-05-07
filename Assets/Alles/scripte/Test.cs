using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
   
        //FunktionTimer.Create(TestAktion, 1f,"Timer1");
        //FunktionTimer.Create(TestAktion1, 6f,"Timer2");
       // FunktionTimer.StopTimer("Timer1");
    }

    private void Update()
    {
       
     
    }
    private void TestAktion()
    {

     
        Debug.Log("Testing1");
        
    }
    private void TestAktion1()
    {
        Debug.Log("Testing2");
    }

}
