using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Zombie_Boss_Leben : MonoBehaviour
{
    public bool z_zombie_boss_leben;
    private Animator anim;
    // [SerializeField]
    // GameObject zombie_leiche;
    public bool d_zombie_boss_drop;
    //public GameObject g_geld;

    public GameObject f_floating_text;
    public Transform t_text_position;

    [SerializeField]
    public Slider s_zombie_boss_slider;
    public float zombie_boss_leben_max;
    float a_aktuelles_boss_leben;
    public bool z_zombie_boss;


    void Start()
    {
        anim = GetComponent<Animator>();
        z_zombie_boss = true;
        z_zombie_boss_leben = true;

        a_aktuelles_boss_leben = zombie_boss_leben_max;
        s_zombie_boss_slider.maxValue = a_aktuelles_boss_leben;
        s_zombie_boss_slider.value = a_aktuelles_boss_leben;
    }
    public void addDamage(float damage)
    {
     

        a_aktuelles_boss_leben -= damage;
        s_zombie_boss_slider.value = a_aktuelles_boss_leben;
        if (f_floating_text && a_aktuelles_boss_leben >= 0)
        {
            showFloatingText();
            SoundManagerScript.PlaySound("zombie_hit");
            SoundManagerScript.PlaySound("baseball_hit");
        }
        if (a_aktuelles_boss_leben <= 0)
        {
            z_zombie_boss = false;
            z_zombie_boss_leben = false;
        }
        if (a_aktuelles_boss_leben <= 0) makeDead();

    }
    void makeDead()
    {
        if (d_zombie_boss_drop == true)
        {
            // Fuer leben oder geld
         //   Instantiate(g_geld, transform.position, transform.rotation);
        }
        // Fuer leiche
        // Instantiate(soldatTot, transform.position, transform.rotation);
        if (z_zombie_boss == false || z_zombie_boss == false)
        {
            //Destroy(this.gameObject);
            //Destroy(this.gameObject.GetComponentInParent<Spieler_Ist_Da>());
            anim.SetTrigger("tot");
        }
    }
    void showFloatingText()
    {
        //this.GetComponent<TextMeshProUGUI>().text = c_current_text;
        var go = Instantiate(f_floating_text, t_text_position.position, Quaternion.identity, transform);
        go.GetComponentInChildren<TextMeshProUGUI>().text = a_aktuelles_boss_leben.ToString();
        // print(a_aktuelles_leben);
    }
}
