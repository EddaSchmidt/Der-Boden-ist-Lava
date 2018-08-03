using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveorb : MonoBehaviour {


		public KeyCode moveL;
		public KeyCode moveR; //Tasten

		public float horizVel = 0; //In welche Line sich der Orb bewegt
		public int laneNum = 0; //guckt in welcher Linie sich der Ball befindet & vermeidet überschreitungen vom Feld
		public string controlLock = "n";
		public int sternzaehler = 0;

        Rigidbody rbSpieler;
        public bool tot = false; //testen ob Spieler noch lebt oder nicht
        
 

    // Use this for initialization
    void Start () {
        rbSpieler = GetComponent<Rigidbody>(); //Rigidbody von Sphere in rbSpieler speichern
    }
	
	// Update is called once per frame
	//Steuerung in Update weil es immer wieder abfragt!
	void Update () {

        //wenn Spieler eingebrochen/tot dann faellt er runter und laeuft nicht weiter
        if (tot == false)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, 4);
        } else
        {
            
            rbSpieler.useGravity = true;
        }

        //Steuerung des Spielers mittels Tastatur (nach Links)
		if((Input.GetKeyDown (moveL)) && (laneNum>-2) && (controlLock == "n")){
			horizVel = -2;
			StartCoroutine (stopSlide());
			laneNum -= 1;
			controlLock = "y";
		}

        //Steuerung des Spielers mittels Tastatur (nach Rechts)
        if ((Input.GetKeyDown (moveR)) && (laneNum<2) && (controlLock == "n")) {
			horizVel = 2;
			StartCoroutine (stopSlide());
			laneNum += 1;
			controlLock = "y";
		}
	}

	// Wenn man der Spieler ein Obstacle beruehrt dann wir tot auf true gesetzt und der spieler laeuft nicht weiter 
	void OnCollisionEnter(Collision other){
		if(other.gameObject.name == "Obstacle"){
            tot = true;
           
            
        }
        //wenn der spieler ein stern sammelt wird der sternenzaehler einen hochh gesetzt
		if(other.gameObject.name == "Stern"){
			Destroy(other.gameObject);
			sternzaehler += 1;
		}
	}


	//Nach einer halben sekunde wird der controllock wieder gelöst
	//Nach einer halben sekunde wird die bewegung gestoppt
	IEnumerator stopSlide(){
		yield return new WaitForSeconds (.5f);
		horizVel = 0;
		controlLock = "n";
	}
}
