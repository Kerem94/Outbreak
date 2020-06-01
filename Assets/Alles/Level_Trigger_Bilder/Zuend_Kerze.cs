using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Zuend_Kerze : MonoBehaviour
{
    public Button z_zuend_kerze;
    Animator z_zuend_kerze_anim;


    private void Start()
    {
        z_zuend_kerze_anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            z_zuend_kerze_anim.SetTrigger("zuend_kerze");
            z_zuend_kerze.interactable = true;
            SceneManager.LoadScene("Waffen_Kaufen");
        }
    }
}
