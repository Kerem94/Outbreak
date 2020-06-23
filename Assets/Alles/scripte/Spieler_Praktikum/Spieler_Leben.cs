using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spieler_Leben : MonoBehaviour
{
   // public GameObject gameoverText;
   // public restartGame theGameManager;
    public float fullHealth;
    float currentHealth;
    public static bool spieler_lebt;
    //public GameObject deathFX;
  
    //HUD Varibales
    public Slider healtSlider;
    public Image damageScreen;
    bool damaged;
    Color damagedColor = new Color(0.91f, 0.3f, 0.21f);
    float smoothColor = 3f;
    //Spieler ist tot
    //public GameObject blut;
    //public Transform blutPos;
   
    // Start is called before the first frame update
    void Start()
    {
        // gameoverText.SetActive(false);
        //currentHealth   = PlayerPrefs.GetFloat("leben");
        currentHealth = fullHealth;
      
        //HUD Initliation
        healtSlider.maxValue = fullHealth;
        healtSlider.value    = currentHealth;
        spieler_lebt = true;
        //currentHealth = PlayerPrefs.GetFloat("leben");
        damaged = false;
      
    }

    // Update is called once per frame

    void Update()
    {
        //falls spieler verletzt     
        if (damaged)
        {
            damageScreen.color = damagedColor;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color,Color.clear,smoothColor*Time.deltaTime);
        }
        damaged = false;
    
    }
    
    public void addDamage(float damage)
    {
        if (damage <= 0)return;
        currentHealth -= damage;
        //PlayerPrefs.SetFloat("leben", currentHealth);
        //Instantiate(blut, blutPos.position, transform.rotation);
        SoundManagerScript.PlaySound("au");
        healtSlider.value = currentHealth;
        damaged = true;
        if (currentHealth <= 0)
        {
            makeDead();
            spieler_lebt = false;
        }
    }

    public void makeDead()
    {
       // Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        damageScreen.color = damagedColor;
        
       // theGameManager.restartTheGame();
       // gameoverText.SetActive(true);
       
    }
    public void addHealth(float health)
    {
        currentHealth += health;
      //  PlayerPrefs.SetFloat("leben", currentHealth);
        if (currentHealth > fullHealth)
        {
            currentHealth = fullHealth;
            healtSlider.value = currentHealth;
        }
    }
}
