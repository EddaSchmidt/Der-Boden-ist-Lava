/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

	void Start () {
		gameObject.SetActive(false);
	}

	void Update() {
		if (!isShowned)
			return;

		transition += Time.deltaTime;
		BackgroundImg.color = Color.Lerp (new Color (0,0,0,0), Color.blck, transition);
	}

	public void ToggleEndMenu(float score){
		gameObject.SetActive(true);
		scoreText.text = ((int)score).ToString ();
		isShowned = true;
	}

	public void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ToMenu(){
		SceneManager.LoadScene("Menu");
	}
}*/