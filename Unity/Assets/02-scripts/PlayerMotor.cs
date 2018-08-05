using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {


    private CharacterController controller;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f; 

    private float speed = 5.0f; // Schnelligkeit festelgen auf 5m pro sekunde

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
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
	}
}
