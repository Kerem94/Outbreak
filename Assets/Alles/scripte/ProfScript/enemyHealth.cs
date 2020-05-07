using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyHealth : MonoBehaviour
{
    // [SerializeField]
    // GameObject soldatTot;
    public GameObject getroffen;
    public Transform blutPos;
    public GameObject floatingText;
    public Transform textPosition;
    //
    public bool drop;
    public GameObject leben;
   // public GameObject epPunkt;
    //
    [SerializeField]
    public Slider soldatSlider;
    public float enemyMaxHealth;
    float currentHealth;
   

    // Start is called before the first frame update
    void Start()
    {
    
        currentHealth = enemyMaxHealth;
        soldatSlider.maxValue = currentHealth;
        soldatSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addDamage(float damage)
    {
        currentHealth -= damage;
        Instantiate(getroffen, blutPos.position, transform.rotation);
        SoundManagerScript.PlaySound("hit");
        soldatSlider.value = currentHealth;
        if (floatingText && currentHealth >= 0)
        {
            showFloatingText();
        }
        if (currentHealth <= 0)
        {
           // EP ex = (EP)FindObjectOfType(typeof(EP));
           // ex.addEP(5);
        }
        if (currentHealth <= 0) makeDead();

    }
    void makeDead()
    {
        SoundManagerScript.PlaySound("dead");
        Destroy(this.gameObject,0.4f);
        // Fuer leiche
        // Instantiate(getroffen, transform.position, transform.rotation);
        //Destroy(this.gameObject);
        //Fuer erfahrung
        if (drop)
        {
            Instantiate(leben, transform.position, transform.rotation);
            //Instantiate(epPunkt, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        //Für die gegner mit gesichtet
        if (transform.parent == true)
        {
            Destroy(transform.parent.gameObject);
        }
    }
    void showFloatingText()
    {
        var go = Instantiate(floatingText, textPosition.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = currentHealth.ToString();
    }
}
