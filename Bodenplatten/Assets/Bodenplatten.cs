using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodenplatten : MonoBehaviour {

	private void platten(){
		// Wir brauchen: 
		//	5 Platten pro Reihe(? Änderbar?)
		//	Platten sollen in einer Liste gefasst sein
		//	Die ersten 10(?) Plattenreihen sind generiert, damit der spieler vorraus schauen kann
		//	wenn der charakter 1 reihe vorrückt, rückt die Liste mit allen Platten eins nach vorne und es wird die erste reihe gelöscht und die letze reihe neu generiert
		//	Die Kamera soll auf Position 0 der Liste angefügt sein damit sie sich immer mitbewegt (charakter auf platz 1 der Liste)
		//	Das Spiel geht unendlich weiter ausser:
		//		- Der spieler sammelt nicht genug Sterne (5 Sterne pro 50 Reihen oder so?)
		//		- Der spieler tritt in eine Falle
		//		- Die Lava holt den Spieler ein (Code muss man noch überlegen??)


				
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
