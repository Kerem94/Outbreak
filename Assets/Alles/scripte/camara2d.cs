using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara2d : MonoBehaviour
{
    public bool maintainWith = true;
    [SerializeField]
    public int adaptPosition;
    float defaultWith;
    float defaultHight;
    public Vector3 CameraPos;
    // Start is called before the first frame update
    void Start()
    {
        defaultWith = Camera.main.orthographicSize * Camera.main.aspect;
        defaultHight = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (maintainWith)
        {
            Camera.main.orthographicSize = defaultWith / Camera.main.aspect;
            Camera.main.transform.position = new Vector3(CameraPos.x, -1 * (defaultHight - Camera.main.orthographicSize), CameraPos.z);
        }
        else
        {
            Camera.main.transform.position = new Vector3(adaptPosition * (defaultWith - Camera.main.orthographicSize * Camera.main.aspect), CameraPos.y, CameraPos.z);
        }
    }

}
