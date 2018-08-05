using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotore : MonoBehaviour { //Kamera ueber spieler setzen

    private Transform lookAt; //Transform hat daten des spielers
    private Vector3 startOffset; // damit kamera nicht auf sondern hinterm spieler ist
    private Vector3 moveVecto; //damit Kamera in mitte bleibt

	// Use this for initialization
	void Start () {
        lookAt = GameObject.FindGameObjectWithTag("spieler").transform; //holt uns spieler objekt und alle Daten Transform von SPieler

        startOffset = transform.position - lookAt.position; // Abstand der Kamera zum Spieler
    }
	
	// Update is called once per frame
	void Update () {
        // Kamer in Mitte festmachen damit nicht nach rechts oder links
        moveVecto = lookAt.position + startOffset;
        //X
        moveVecto.x = 0; //kamera im zenter nicht nach rechts oder links
        

        transform.position = moveVecto; //camera position ist selbe wie spieler position

    }
}
