using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunktion : MonoBehaviour
{
    //Soldat1
    public static bool d1Los1,d1Los2;
    //Soldat2
    public static bool d2Los1,d2Los2;
    //Soldat3
    public static bool d3Los1,d3Los2;
    //Soldat4
    public static bool d4Los1,d4Los2;
    //Briten Soldat1
    public static bool bLos1;

    //Soldat1
    public void d1l1()
    {
        d1Los2 = false;
        d1Los1 = true;
      
    }

    public void d1l2()
    {
       d1Los1 = false;
       d1Los2 = true;
    }
    //Soldat2
    public void d2l1()
    {
        d2Los1 = false;
        d2Los1 = true;

    }

    public void d2l2()
    {
        d2Los1 = false;
        d2Los2 = true;
    }
    //Soldat3
    public void d3l1()
    {
        d3Los1 = false;
        d3Los1 = true;

    }

    public void d3l2()
    {
        d3Los1 = false;
        d3Los2 = true;
    }
    //Soldat4
    public void d4l1()
    {
        d4Los1 = false;
        d4Los1 = true;

    }

    public void d4l2()
    {
        d4Los1 = false;
        d4Los2 = true;
    }
    public void briten()
    {
        bLos1 = true;
    }
}
