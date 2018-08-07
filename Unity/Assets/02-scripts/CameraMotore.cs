using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotore : MonoBehaviour { //Kamera ueber spieler setzen

    private Transform lookAt; //Transform hat daten des spielers
    private Vector3 startOffset; // damit kamera nicht auf sondern hinterm spieler ist
    private Vector3 moveVecto; //damit Kamera in mitte bleibt


    //für Kamera animation in den ersten paar sekunden:
    private float transition = 0.0f; // wenn spiel startet
    private float animationDuration = 3.0f; //Animation Dauer
    private Vector3 animationOffset = new Vector3(0,5,5);


	void Start () {
        lookAt = GameObject.FindGameObjectWithTag("spieler").transform; //holt uns spieler objekt und alle Daten Transform von SPieler

        startOffset = transform.position - lookAt.position; // Abstand der Kamera zum Spieler
    }
	
	// Update is called once per frame
	void Update () {

        //Normale bewegung der Kamera: 
        
        moveVecto = lookAt.position + startOffset; // Kamer in Mitte festmachen damit nicht nach rechts oder links
        //X
        moveVecto.x = 0; //kamera im zenter nicht nach rechts oder links
        
        if (transition > 1.0f) //wenn ja dann mache die normale Kamera bewegung
        {
            transform.position = moveVecto; //camera position ist selbe wie spieler position
        } else
        {
            // Animation am anfang des Spieles
            transform.position = Vector3.Lerp(moveVecto + animationOffset, moveVecto, transition); //Kamera ueber spieler
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up); // Kamera schaut spieler an während animation
        }
        

    }
}
