using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAll : MonoBehaviour { 

    public void delteAll()
    {
        PlayerPrefs.DeleteAll();
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            PlayerPrefs.DeleteAll();
            print("Alle daten gelöscht");
        }
    }
}
