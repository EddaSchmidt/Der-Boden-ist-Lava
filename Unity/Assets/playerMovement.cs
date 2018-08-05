using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {


    public Rigidbody rb;
    public float thrust = 1;
    Vector3 playerZ = new Vector3(1f, 0, 0);

	void Update () {
        rb.AddForce(1, 0, 0);

        if(Input.GetKeyDown("a")) {
            rb.MovePosition(new Vector3(1.0f, 0, 20f) * Time.deltaTime);
        }






	}

 
}
