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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	//Steuerung in Update weil es immer wieder abfragt!
	void Update () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (horizVel,0,4);

		if((Input.GetKeyDown (moveL)) && (laneNum>-2) && (controlLock == "n")){
			horizVel = -2;
			StartCoroutine (stopSlide());
			laneNum -= 1;
			controlLock = "y";
		}

		if((Input.GetKeyDown (moveR)) && (laneNum<2) && (controlLock == "n")) {
			horizVel = 2;
			StartCoroutine (stopSlide());
			laneNum += 1;
			controlLock = "y";
		}
	}

	// Wenn man das Object mit dem Tag lethal trifft wird das männchen zerstört
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "lethal"){
			Destroy (gameObject);
		}
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
