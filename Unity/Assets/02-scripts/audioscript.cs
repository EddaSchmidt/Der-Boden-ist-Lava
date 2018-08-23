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

    private PlayerMotor spiel;
    public bool tot;
    private int stern;
    private int altStern = 0;

    // Use this for initialization
    void Start(){
        MusicSource1.clip = MusicClip;
        MusicSource2.clip = Sterben;
        MusicSource3.clip = Anfang;

        spiel = GetComponent<PlayerMotor>();
        

    }

    // Update is called once per frame
    void Update()
    {
        tot = GetComponent<PlayerMotor>().isDead;
        stern = GetComponent<PlayerMotor>().eingesammelt;

        if (Input.GetKeyDown(KeyCode.Space))
            MusicSource1.Play();

        if (tot == true)
        {
            MusicSource1.Stop();
            MusicSource2.Play();
        }
        if(stern != altStern)
        {
            MusicSource3.Play();
            altStern = stern;
        }
        
    }
}

