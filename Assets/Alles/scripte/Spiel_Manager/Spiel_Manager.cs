using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spiel_Manager : MonoBehaviour
{
   public static int lvl=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
            print("raus");
        }
    }



    public void exit()
    {
        if (lvl == 1)
        {
            SceneManager.LoadScene("Level_2");
            print("level 2");
        }
        if (lvl == 2)
        {
            SceneManager.LoadScene("Level_3");
            print("level 3");
        }
        if (lvl == 3)
        {
            SceneManager.LoadScene("Level_4");
            print("Boss fight");
        }

    }


}
