using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour {

    public moveorb mymoveorb; 

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);
	}
	
	// Update is called once per frame
	void Update () {
        
		if (mymoveorb.tot == true)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        
	}
}
