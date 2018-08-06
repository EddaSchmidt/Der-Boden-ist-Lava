using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour {

    public GameObject player;
    public GameObject groundPlate;




    void breakIn() {

    }

    void fallDown() {

    }

    void lavaWaveCatch() {

    }

    void Update () {

    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.name == "GroundPlate") {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Collision happened!");
        }
    }
}
