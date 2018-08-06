using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveorb : MonoBehaviour {


		public KeyCode moveL;
		public KeyCode moveR; //Tasten

		public float horizVel = 0; //In welche Line sich der Orb bewegt
		public int laneNum = 0; //guckt in welcher Linie sich der Ball befindet & vermeidet überschreitungen vom Feld
		public string controlLock = "n";
		public int count;
		public Text countText;
		public Text winText;


        Rigidbody rbSpieler;
        public bool tot = false; //testen ob Spieler noch lebt oder nicht
        
 

    // Use this for initialization
    void Start () {
        rbSpieler = GetComponent<Rigidbody>(); //Rigidbody von Sphere in rbSpieler speichern
        count = 0;
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

	// Wenn der Spieler ein Obstacle beruehrt dann wird tot auf true gesetzt und der spieler laeuft nicht weiter 
	void OnCollisionEnter(Collision other){
		if(other.gameObject.name == "Obstacle"){
            tot = true;   
           
           

        }
        //wenn der spieler ein stern sammelt wird der sternenzaehler einen hochh gesetzt
		if(other.gameObject.name == "Stern"){
			Destroy(other.gameObject);
			count += 1;
			GM.zVelAdj = 0;
		}
	}

	/*void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }*/


	//Nach einer halben sekunde wird der controllock wieder gelöst
	//Nach einer halben sekunde wird die bewegung gestoppt
	IEnumerator stopSlide(){
		yield return new WaitForSeconds (.5f);
		horizVel = 0;
		controlLock = "n";
	}
}
