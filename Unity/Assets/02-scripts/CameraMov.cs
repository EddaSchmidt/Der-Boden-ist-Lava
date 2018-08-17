using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour {

    public moveorb myEinbruch;

    // Use this for initialization
    void Start () {
        //Camera Movement
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0 , 4);
	}
	
	// Update is called once per frame
	void Update () {
        
        //wenn Spieler eingebrochen bleibt Camera stehen
        if (myEinbruch.tot == true)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        
	}
}
