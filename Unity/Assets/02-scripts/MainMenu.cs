using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    public void startGame() {
        SceneManager.LoadScene("SampleScene");
    }

    public void exitGame() {
        Debug.Log("EXIT");
        Application.Quit();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
