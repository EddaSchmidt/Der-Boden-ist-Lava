using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Einbrechen : MonoBehaviour {

    private Rigidbody rigidPlatte;
    public bool eingebrochen = false;
    public GameObject destroyedVersion;


    // Use this for initialization
    void Start()
    {
        rigidPlatte = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "spieler")
        {
            rigidPlatte.isKinematic = false;
            eingebrochen = true;
            //Instantiate(destroyedVersion, transform.position, transform.rotation);
            

        }
    }
}
