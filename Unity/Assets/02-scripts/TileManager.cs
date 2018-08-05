using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = -6.0f; // wo in z achse soll bruecken teil hin
    private float brueckelength = 3.0f;
    private float safeZone = 15.0f;
    private int amnTilesOnScreen = 10;

    private List<GameObject> activeTiles;

	// Use this for initialization
	void Start () {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("spieler").transform;

        for (int i = 0; i<amnTilesOnScreen; i++)
        {
            SpawnTile();
            DeleteTile();

        }
    }
	
	// Update is called once per frame
	void Update () {
		if (playerTransform.position.z - safeZone > (spawnZ -amnTilesOnScreen* brueckelength))
        {
            SpawnTile();
        }
	}

    private void SpawnTile(int prefabIndex = -1) // auf -1 damit
    {
        GameObject go;
        go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ; //bruecke vorwärts machen
        spawnZ += brueckelength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
