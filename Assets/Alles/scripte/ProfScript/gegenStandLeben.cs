using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gegenStandLeben : MonoBehaviour
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
     
        //Instantiate(getroffen, transform.position, transform.rotation);
        soldatSlider.value = currentHealth;
        if (floatingText && currentHealth >= 0)
        {
            showFloatingText();

        }
        if (currentHealth <= 0)
        {

            // d.feindDa = false;
        }
        if (currentHealth <= 0) makeDead();

    }
    void makeDead()
    {
      
        Destroy(this.gameObject);
        // Fuer leiche
        // Instantiate(getroffen, transform.position, transform.rotation);
        //Destroy(this.gameObject);
        if (drop)
        {
            Instantiate(leben, transform.position, transform.rotation);
        }
    }
    void showFloatingText()
    {
        var go = Instantiate(floatingText, textPosition.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = currentHealth.ToString();
    }
 
}
