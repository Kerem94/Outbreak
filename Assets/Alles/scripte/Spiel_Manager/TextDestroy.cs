using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDestroy : MonoBehaviour
{
    public float destroyText = 0.1f;
    //Text
    Vector3 Offset = new Vector3(0, 0.2f, 0);
    Vector3 RandomIntensity = new Vector3(0.3f, 0, 0);
    // public Vector3 Offset = new Vector3(0, 0, 0);

    void Start()
    {
        transform.localPosition += Offset;
        transform.localPosition += new Vector3(Random.Range(-RandomIntensity.x, RandomIntensity.x),
            Random.Range(-RandomIntensity.y, RandomIntensity.y),
        Random.Range(-RandomIntensity.z, RandomIntensity.z));
    }

    void Update()
    {
        Destroy(gameObject,destroyText);
       // transform.localPosition += Offset;
    }
}
