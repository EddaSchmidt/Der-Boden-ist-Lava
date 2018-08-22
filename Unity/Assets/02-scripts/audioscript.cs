using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioscript : MonoBehaviour
{

    public AudioClip MusicClip; //Musicdatei

    public AudioSource MusicSource1; //AUdioobjekt
    public AudioSource MusicSource2; 
    public AudioSource MusicSource3; 
    public AudioClip Sterben;
    public AudioClip Anfang;


    // Use this for initialization
    void Start(){
        MusicSource1.clip = MusicClip;
        MusicSource2.clip = Sterben;
        MusicSource3.clip = Anfang;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            MusicSource1.Play();

    }
}

