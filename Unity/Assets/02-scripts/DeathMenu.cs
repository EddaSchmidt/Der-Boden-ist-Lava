using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public Text scoreText; 
	public Image BackgroundImg; // on top off death menu, bei uns einfach schwarze

	private bool isShowned = false; 

	private float transition = 0.0f;

	void Start () {
		gameObject.SetActive(false); //am anfang menu nicht sehen
	}

	void Update() {
		if (!isShowned) //menu noch nicht zeigen
            return; //dann nichts machen

		transition += Time.deltaTime;
		BackgroundImg.color = Color.Lerp (new Color (0,0,0,0), Color.black, transition); //bissel durchsichtig
	}

	/*public void ToggleEndMenu(float score){
		gameObject.SetActive(true); //man sieht death menu wenn tot
		scoreText.text = ((int)score).ToString (); 
		isShowned = true;
	}*/

	public void Restart() {
        //fuer play button das er wieder startet
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); //man lädt die szene auf der man gerade ist also lädt szene Spiel, simuliert quasi restart
	}

	public void ToMenu(){
        //fuer menu aber jetzt 
        //andere variante dort lädt der Szene Manager die Szene namens Menu (gibt es jetzt noch nicht)
		SceneManager.LoadScene("Menu");
	}
}