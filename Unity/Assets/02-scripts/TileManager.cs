using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = -6.0f; // wo in z achse soll erstes bruecken teil hin
    private float brueckelength = 2.0f;
    private float safeZone = 17.0f; //erstmal keine Effekte damit der spieler anlaufen kann
    private int amnTilesOnScreen = 22; //wie viele prefabs man aufm screen sehen soll
    private int lastPrefabIndex = 0; //samit man nicht 2x hintereinander selben prefab hat

    private List<GameObject> activeTiles;

	// Use this for initialization
	void Start () {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("spieler").transform;

        for (int i = 0; i<amnTilesOnScreen; i++)
        {
            // am anfang normale Brücke und danach random brücke
            if (i<9 )
            {
                SpawnTile(0);
            } else
            {
                SpawnTile();
            }
            

        }
    }
	
	void Update () {
        //Infinity runner
		if (playerTransform.position.z - safeZone > (spawnZ -amnTilesOnScreen* brueckelength))
        {
            SpawnTile(); 
            DeleteTile();
        }
	}

    private void SpawnTile(int prefabIndex = -1) // auf -1 damit
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ; //bruecke vorwärts machen
        spawnZ += brueckelength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]); //letztes element loeschen
        activeTiles.RemoveAt(0); //ebenfalls element aus liste loeschen
    }

    private int RandomPrefabIndex() //random reihenfolge der prefabs
    {
        if (tilePrefabs.Length <= 1) //wenn nur ein prefab in liste dann return 0
            return 0;

        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex) //damit man nicht 2x dasselbe prefab hat
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
