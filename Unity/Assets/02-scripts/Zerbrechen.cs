using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zerbrechen : MonoBehaviour {

    public float cubeGroesse = 0.2f;
    public int cubesTeile = 5;
    public GameObject spieler;
    GameObject fon;

	// Use this for initialization
	void Start () {
        //spieler = GameObject.FindGameObjectWithTag("spieler");
	}
	
	// Update is called once per frame
	void Update () {
        fon = GameObject.FindGameObjectWithTag("fountain");
        fon.SetActive(false);
        /*
        lava = GameObject.FindGameObjectWithTag("einbrechen");
        lava.GetComponent<Transform>();
        Debug.Log(lava);


        if (lava.transform.position.z == spieler.transform.position.z) {
            brechen(lava);
        }

    */
        FindClosestEnemy(); // der am naehsten ist explodiert
    }

    void FindClosestEnemy() {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("einbrechen");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
         brechen(closest);
    }

    public void brechen(GameObject obj) {
        obj.SetActive(false);
        fon.SetActive(true);
    }
}
