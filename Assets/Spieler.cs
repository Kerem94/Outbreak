using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class Spieler : MonoBehaviour
{
    //Canvas
    public GameObject waffe1_Bild;
    public GameObject waffe2_Bild;
    public GameObject waffe3_Bild;
    //Texte fuer ammo stand
    public Text waffenText1, waffenText2, waffenText3;
    //Jojstick
    public Joystick joysstick;
    private Button btnRechts;
    //Fue spiel Gamobjekte
    public GameObject werkzeug;
    public GameObject waffe1;
    public GameObject waffe2;
    public GameObject waffe3;

    //public GameObject granate;
    private Rigidbody2D rb;
    private Animator anim;
    public GameObject weapon;
    private Vector2 moveVelocity;
    public float speed;
    float move = 0f;
    bool facingRight;
    //Camera Handler
    public static int camera2 = 0;
    //Varible fuer Waffe wechsel
    public static int waffe_wechsel;
    //Waffen Monition
    public static int waffe1Ammo = 5;
    public static int waffe1AmmoReserve;
    public static int waffe2Ammo = 30;
    public static int waffe2AmmoReserve;
    public static int waffe3Ammo = 3;
    public static int waffe3AmmoReserve;
    //jumping varible
    bool grounded = false;
    public float groundedCheckRadius = 0.4f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    bool knie;
    public static bool isTunel;
    private void Start()
    {
        werkzeug.SetActive(false);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        waffenText1.GetComponent<Text>();
        waffenText2.GetComponent<Text>();
        waffenText3.GetComponent<Text>();
        btnRechts = GetComponent<Button>();
        facingRight = true;
    }

    private void Update()
    {
        waffenstand1();
        waffenstand2();
        waffenstand3();
        if (PlayerPrefs.GetInt("waffe_wechsel") == PlayerPrefs.GetInt("bild1"))
        {
            waffe1_Bild.SetActive(true);
            waffe1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("waffe_wechsel") == PlayerPrefs.GetInt("bild2"))
        {
            waffe2_Bild.SetActive(true);
            waffe2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("waffe_wechsel") == PlayerPrefs.GetInt("bild3"))
        {
            waffe3_Bild.SetActive(true);
            waffe3.SetActive(true);
        }
        //Wafffen Wechsel
        if (waffe_wechsel == 1)
        {

            if (PlayerPrefs.GetInt("bild1") == PlayerPrefs.GetInt("waffe_wechsel"))
            {
                waffe1_Bild.SetActive(true);
                waffe1.SetActive(true);
                waffe2_Bild.SetActive(false);
                waffe2.SetActive(false);
                waffe3_Bild.SetActive(false);
                waffe3.SetActive(false);
            }
            PlayerPrefs.SetInt("waffe1", 1);
            PlayerPrefs.SetInt("bild1", 1);
            PlayerPrefs.SetInt("waffe_wechsel", 1);
            PlayerPrefs.SetInt("waffe2", 5);
            PlayerPrefs.SetInt("waffe3", 6);
        }
        else if (waffe_wechsel == 2)
        {
            if (PlayerPrefs.GetInt("bild2") == PlayerPrefs.GetInt("waffe_wechsel"))
            {
                waffe2_Bild.SetActive(true);
                waffe2.SetActive(true);
                waffe1_Bild.SetActive(false);
                waffe1.SetActive(false);
                waffe3_Bild.SetActive(false);
                waffe3.SetActive(false);
            }
            PlayerPrefs.SetInt("waffe2", 2);
            PlayerPrefs.SetInt("bild2", 2);
            PlayerPrefs.SetInt("waffe_wechsel", 2);
            PlayerPrefs.SetInt("waffe1", 0);
            PlayerPrefs.SetInt("waffe3", 6);
        }
        else if (waffe_wechsel == 3)
        {
            if (PlayerPrefs.GetInt("bild3") == PlayerPrefs.GetInt("waffe_wechsel"))
            {
                waffe3_Bild.SetActive(true);
                waffe3.SetActive(true);
                waffe2_Bild.SetActive(false);
                waffe2.SetActive(false);
                waffe1_Bild.SetActive(false);
                waffe1.SetActive(false);
            }

            waffe3_Bild.SetActive(true);
            waffe3.SetActive(true);
            PlayerPrefs.SetInt("waffe3", 3);
            PlayerPrefs.SetInt("bild3", 3);
            PlayerPrefs.SetInt("waffe_wechsel", 3);
            PlayerPrefs.SetInt("waffe2", 5);
            PlayerPrefs.SetInt("waffe1", 0);


        }

        Weapon waffe = GetComponentInChildren(typeof(Weapon)) as Weapon;
        //Links Rechts
        if (joysstick.Horizontal >= .2f && (grounded = true) && (knie == false))
        {
            move = speed;
            knie = false;
        }
        else if (joysstick.Horizontal <= -.2f && (grounded = true) && (knie == false))
        {
            move = -speed;
            knie = false;
        }
        else
        {
            move = 0f;
        }

        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        //Bewegeung Spieler
        anim.SetFloat("speed", Mathf.Abs(move));
        //Spriengen
        float verticalMove = joysstick.Vertical;
        if (verticalMove >= .2f && rb.velocity.y == 0 && grounded == true)
        {
            grounded = false;
            anim.SetBool("isGrounded", grounded);
            rb.AddForce(new Vector2(0, jumpHeight));
        }
        //check if are groundet
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundedCheckRadius, groundLayer);
        anim.SetFloat("verticalSpeed", rb.velocity.y);
        anim.SetBool("isGrounded", grounded);
        //Knie

        if (verticalMove <= -.2f)
        {
            anim.SetBool("knie", true);
            knie = true;
        }
        /*
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    //rotate the sprite about the Z axis in the negative direction
                    transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * speed, Space.World);
                    anim.SetBool("knie", true);
                    pl = GetComponent<BoxCollider2D>();
                    pl.offset.Set( 3f, -0.71f);
                    pl.size.Set(0.3f, 48f);
                }*/
        else
        {
            anim.SetBool("knie", false);
            knie = false;
        }

        if (move > 0 && !facingRight)
        {

            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }
    }
    public void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("werkzeugkasten"))
        {
            SoundManagerScript.PlaySound("box");
            werkzeug.SetActive(true);
        }
        /*
        if (collision.CompareTag("Enemy"))
        {
         
            anim.SetTrigger("isKampf");
        }*/
        if (collision.CompareTag("vernichte"))
        {

            CameraSwitch cs = GameObject.FindGameObjectWithTag("GM").GetComponent<CameraSwitch>();
            //cs.cameraChangeCounter();
            camera2++;


        }
        if (collision.CompareTag("D_weg1"))
        {
            camera2--;
        }
    }
    public void waffeWechselnRechts()
    {
        waffe_wechsel++;
        if (waffe_wechsel >= 3)
        {
            waffe_wechsel = 3;
            print(waffe_wechsel + "nachOben");
        }
    }
    public void waffeWechselnLinks()
    {
        waffe_wechsel--;
        if (waffe_wechsel <= 0)
        {
            waffe_wechsel = 1;
            print(waffe_wechsel + "nachUnten");
        }
    }

    public void waffenstand1()
    {
        //waffe ammo statnd Waffe2
        waffenText1.text = waffe1Ammo.ToString() + "X" + waffe1AmmoReserve.ToString();
        if (waffe1Ammo > 5)
        {
            waffe1AmmoReserve += 1;
            waffe1Ammo = 0;
        }
        else if (waffe1Ammo == 0 && waffe1AmmoReserve >= 1)
        {
            waffe1Ammo += 5;
            waffe1AmmoReserve--;
        }
        else if (waffe1AmmoReserve == 0)
        {
            waffe1AmmoReserve = 0;
        }
    }
    public void waffenstand2()
    {
        //waffe ammo statnd Waffe2
        waffenText2.text = waffe2Ammo.ToString() + "X" + waffe2AmmoReserve.ToString();
        if (waffe2Ammo > 30)
        {
            waffe2AmmoReserve += 1;
            waffe2Ammo = 0;
        }
        else if (waffe2Ammo == 0 && waffe2AmmoReserve >= 1)
        {
            waffe2Ammo += 30;
            waffe2AmmoReserve--;
        }
        else if (waffe2AmmoReserve == 0)
        {
            waffe2AmmoReserve = 0;
        }
    }
    public void waffenstand3()
    {
        //waffe ammo statnd Waffe2
        waffenText3.text = waffe3Ammo.ToString() + "X" + waffe3AmmoReserve.ToString();
        if (waffe3Ammo > 5)
        {
            waffe3AmmoReserve += 1;
            waffe3Ammo = 0;
        }
        else if (waffe3Ammo == 0 && waffe3AmmoReserve >= 1)
        {
            waffe3Ammo += 5;
            waffe3AmmoReserve--;
        }
        else if (waffe3AmmoReserve == 0)
        {
            waffe3AmmoReserve = 0;
        }
    }




}