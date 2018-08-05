using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour {

    public Einbrechen myEinbruch;

    // Use this for initialization
    void Start () {
        //Camera Movement
        GetComponent<Rigidbody>().velocity = new Vector3(0,GM.vertVel, 4*GM.zVelAdj);
	}
	
	// Update is called once per frame
	void Update () {
        
        //wenn Spieler eingebrochen bleibt Camera stehen
        if (myEinbruch.eingebrochen == true)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        
	}
}
