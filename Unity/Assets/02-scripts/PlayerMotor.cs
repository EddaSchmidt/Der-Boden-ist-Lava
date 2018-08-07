using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {


    private CharacterController controller;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f; 

    private float speed = 5.0f; // Schnelligkeit festelgen auf 5m pro sekunde

    private float animationDuration = 3.0f; //spieler darf in ersten 3 sek nicht bewegen
    private float startTime; // damit der spieler sich am anfang nicht bewegt

    private bool isDead = false;

    public int sternzaehler = 0;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

        if (isDead) // wenn spieler tot dann nur return also spieler movement nicht mehr updaten
            return;

        if (Time.time - startTime < animationDuration) { //damit der spieler sich nicht am anfang bewegt
            controller.Move (Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if (controller.isGrounded) // wenn Spieler auf Boden ist
        {
            verticalVelocity = -0.5f; //Spieler faellt nicht wird nur auf Boden gedrückt
        } else //nicht auf Boden
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //Vektoren jedes mal neu berechnen
        //X - Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed; //Spieler kann rechts und links gehen
        //Y - Up and Down
        moveVector.y = verticalVelocity;
        //Z - Foward and Backward
        moveVector.z = speed; 

        controller.Move(moveVector * Time.deltaTime); //Spieler bewegen, Time.deltaTime damit er nicht so schnell lauft

        //wenn spieler runterfällt soll deathmenu aufgerufen werden
        if (controller.transform.position.y < -10)
        {
            Death();
        }

	}

    //aufruf jedes mal wenn der Spieler etwas beruehrt
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        
        //STERN
         if (hit.gameObject.tag == "Stern")
        {
            sternzaehler++;
            //Stern verschwindet
            Destroy(hit.gameObject);
            Debug.Log(sternzaehler);
        }

         //EINBRECHEN   
        Rigidbody body = hit.collider.attachedRigidbody;
         if (hit.gameObject.tag == "einbrechen")
        {
            body.useGravity = true;
        }
        
    }
    

    private void Death(){

        isDead = true;
        GetComponent<Highscore> ().OnDeath();
    }
}
