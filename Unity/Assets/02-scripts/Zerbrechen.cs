using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zerbrechen : MonoBehaviour {

    public float cubeGroesse = 0.2f;
    public int cubesTeile = 5;
    GameObject lava;
    public GameObject spieler;

	// Use this for initialization
	void Start () {
        //spieler = GameObject.FindGameObjectWithTag("spieler");
	}
	
	// Update is called once per frame
	void Update () {
        /*
        lava = GameObject.FindGameObjectWithTag("einbrechen");
        lava.GetComponent<Transform>();
        Debug.Log(lava);


        if (lava.transform.position.z == spieler.transform.position.z)
        {
            brechen(lava);
        }

    */
        FindClosestEnemy(); // der am naehsten ist explodiert
    }

    void FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("einbrechen");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
         brechen(closest);
    }


    public void brechen(GameObject obj)
    {
        for (int x = 0; x < 1; x++)
        {
            for (int y = 0; y < 1; y++)
            {
                for (int z = 0; z < 1; z++)
                {
                    createTeile(x, y, z, obj);
                }
            }
        }

    }

    void createTeile(int x, int y, int z, GameObject obj)
    {
        GameObject teilchen;
        teilchen = GameObject.CreatePrimitive(PrimitiveType.Cube);

        teilchen.transform.position = obj.transform.position + new Vector3(cubeGroesse * x + 0.5f, cubeGroesse * y, cubeGroesse * z + 1.25f);
        teilchen.transform.localScale = new Vector3(cubeGroesse, cubeGroesse, cubeGroesse);

        teilchen.AddComponent<Rigidbody>();
        teilchen.GetComponent<Rigidbody>().mass = cubeGroesse;


    }

}
