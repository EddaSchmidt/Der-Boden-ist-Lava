using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zerbrechen : MonoBehaviour {

    public float cubeGroesse = 0.2f;
    public int cubesTeile = 5;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerENter(Collider other)
    {
        if (other.gameObject.name == "spieler")
        {
            brechen();
        }
    }

    public void brechen()
    {
        //Obstacle verschwinden lassen
        gameObject.SetActive(false);

        for (int x = 0; x < cubesTeile; x++) {
            for (int y = 0; y < cubesTeile; y++) {
                for (int z = 0; z < cubesTeile; z++) {
                    createTeile(x, y, z);
                }
            }
        }

    }

    void createTeile(int x, int y, int z)
    {
        GameObject teilchen;
        teilchen = GameObject.CreatePrimitive(PrimitiveType.Cube);

        teilchen.transform.position = transform.position + new Vector3(cubeGroesse * x, cubeGroesse * y, cubeGroesse * z);
        teilchen.transform.localScale = new Vector3(cubeGroesse, cubeGroesse, cubeGroesse);

        teilchen.AddComponent<Rigidbody>();
        teilchen.GetComponent<Rigidbody>().mass = cubeGroesse;
    }

}
