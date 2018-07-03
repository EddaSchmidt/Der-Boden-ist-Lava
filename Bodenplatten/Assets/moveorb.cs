using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveorb : MonoBehaviour {


		public KeyCode moveL;
		public KeyCode moveR; //Tasten

		public float horizVel = 0; //In welche Line sich der Orb bewegt
		public int laneNum = 0; //guckt in welcher Linie sich der Ball befindet & vermeidet überschreitungen vom Feld
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (horizVel,0,4);

		if(Input.GetKeyDown (moveL) && (laneNum>-2)){
			horizVel = -2;
			StartCoroutine (stopSlide());
			laneNum -= 1;
		}
		if(Input.GetKeyDown (moveR) && (laneNum<2)) {
			horizVel = 2;
			StartCoroutine (stopSlide());
			laneNum += 1;
		}
	}
	IEnumerator stopSlide(){
		yield return new WaitForSeconds (.5f);
		horizVel = 0;
	}
}
