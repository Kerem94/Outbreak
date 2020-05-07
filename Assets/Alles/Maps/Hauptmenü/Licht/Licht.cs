﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Licht : MonoBehaviour
{
    Light fireLight;
    float lightInt;
    public float minInt = 3f, maxInt = 5f;

    public void Start()
    {
        fireLight = GetComponent<Light>();
    }
    // Update is called once per frame
    void Update()
    {
        lightInt = Random.Range(minInt, maxInt);
        fireLight.intensity = lightInt;
    }
}
