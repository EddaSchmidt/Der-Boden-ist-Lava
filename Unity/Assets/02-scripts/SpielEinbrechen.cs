using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielEinbrechen : MonoBehaviour {

    private Rigidbody rigidPlatte;
    //public bool eingebrochen = false;
    //public GameObject remains;

    void Start()
    {
        rigidPlatte = GetComponent<Rigidbody>();
    }


    void Update()
    {

    }



    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "spieler")
        {
            rigidPlatte.useGravity = true;
            //eingebrochen = true;
            //Instantiate(remains, transform.position, transform.rotation);
            //Destroy(gameObject);



        }
    }
}
