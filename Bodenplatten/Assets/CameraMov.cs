using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour {

    public Einbrechen myEinbruch; 

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);
	}
	
	// Update is called once per frame
	void Update () {
        
		if (myEinbruch.eingebrochen == true)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        
	}
}
