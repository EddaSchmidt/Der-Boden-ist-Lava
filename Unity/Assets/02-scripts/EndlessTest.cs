using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTest : MonoBehaviour {

    public GameObject player;
    public int[][] myArr = new int[200][];
    public Vector3 playerPosition;

    private bool isMoving = false;



	// Use this for initialization
	void Start () {
		for (float i = 0; i < 200f; i++) {
            for (float j = 0; j < 5f; j++) {

                
                if (Random.Range(1f, 10f) > 3f) {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.localScale = new Vector3(0.8f, 0.2f, 0.8f);
                    cube.transform.position = new Vector3(j, 0, i);
                } else {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.localScale = new Vector3(0.8f, 0.2f, 0.8f);
                    sphere.transform.position = new Vector3(j, 0, i);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        playerPosition = player.transform.position;

		if (Input.GetKeyDown(KeyCode.W)) {
            isMoving = true;
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            isMoving = true;
        }

        if (isMoving == true) {

        }
	}
}
