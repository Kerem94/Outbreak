﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    private static SoundManagerScript instance;
    public static AudioClip main_song, spiel_start_song,shotgun_laden,shotgun_schuss;
    static AudioSource audioSrc;
    // Use this for initialization
    void Start()
    {
        main_song = Resources.Load<AudioClip>("main_song");
        spiel_start_song = Resources.Load<AudioClip>("spiel_start_song");
        shotgun_laden    = Resources.Load<AudioClip>("shotgun_laden");
        shotgun_schuss   = Resources.Load<AudioClip>("shotgun_schuss");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "main_song":
                audioSrc.PlayOneShot(main_song);
                break;
            case "spiel_start_song":
                 audioSrc.PlayOneShot(spiel_start_song);
                break;
            case "shotgun_laden":
                audioSrc.PlayOneShot(shotgun_laden);
                break;
            case "shotgun_schuss":
                audioSrc.PlayOneShot(shotgun_schuss);
                break;
        }
    }

   

}
