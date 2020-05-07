﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairs : MonoBehaviour
{
    //Neu
    private Vector3 target;
   
    public GameObject crosshairs;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
         target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        
        crosshairs.transform.position = new Vector2(target.y, target.x);

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

    }
}
