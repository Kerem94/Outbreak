using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Ball : MonoBehaviour
{
    public GameObject z_zombie_blut;
    public Transform b_zombie_blut_pos;
    public PolygonCollider2D p_pl_collider;
    Zombie_Leben z_zl;
    Camera_Manager cm;
    void Start()
    {
        z_zl = GameObject.FindObjectOfType(typeof(Zombie_Leben)) as Zombie_Leben;
        cm = GameObject.FindGameObjectWithTag("Zombie_Animation_Kontroller").GetComponent<Camera_Manager>();
        p_pl_collider.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            p_pl_collider.enabled = true;
        }
        else if(Input.GetKeyUp(KeyCode.F))
        {
            p_pl_collider.enabled = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("zombie_kopf"))
        {
            z_zl = GameObject.FindObjectOfType(typeof(Zombie_Leben)) as Zombie_Leben;
            z_zl.addDamage(10);
            Instantiate(z_zombie_blut, b_zombie_blut_pos.transform.position, transform.rotation);
            cm.z_zombie_getroffen();
          //  print("Zombie getroffen");
        }
    }

}
