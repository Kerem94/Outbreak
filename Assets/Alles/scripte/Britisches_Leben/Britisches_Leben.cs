using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Britisches_Leben : MonoBehaviour
{
    public bool b_britisches_soldaten_leben;
    // [SerializeField]
    // GameObject soldatTot;
    public GameObject f_floating_text;
    public Transform t_text_position;

    [SerializeField]
    public Slider s_soldaten_slider;
    public float britisches_soldaten_leben_max;
    float a_aktuelles_leben;
    public bool britisches_soldat;

    void Start()
    {

        britisches_soldat = true;
        b_britisches_soldaten_leben = true;

        a_aktuelles_leben = britisches_soldaten_leben_max;
        s_soldaten_slider.maxValue = a_aktuelles_leben;
        s_soldaten_slider.value = a_aktuelles_leben;
    }
    public void addDamage(float damage)
    {
        a_aktuelles_leben -= damage;
        s_soldaten_slider.value = a_aktuelles_leben;
        if (f_floating_text && a_aktuelles_leben >= 0)
        {
            showFloatingText();
        }
        if (a_aktuelles_leben <= 0)
        {
            britisches_soldat = false;
            b_britisches_soldaten_leben = false;
        }
        if (a_aktuelles_leben <= 0) makeDead();

    }
    void makeDead()
    {

        // Fuer leiche
        // Instantiate(soldatTot, transform.position, transform.rotation);
        if (britisches_soldat == false || britisches_soldat == false)
        {
            Destroy(this.gameObject);
        }
    }
    void showFloatingText()
    {
        var go = Instantiate(f_floating_text, t_text_position.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = a_aktuelles_leben.ToString();
    }

}
