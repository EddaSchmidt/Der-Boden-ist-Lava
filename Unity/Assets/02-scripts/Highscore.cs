using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {
	public float highscor = 0.0f;
	private int difficultyLevel = 1; 
	private int maxDifficultylevel =  10;
	private int highscoreToNextLevel = 10;

	private bool isDead = false;

	public Text highscoreText;
	public DeathMenu deathMenu;


	//Update is calles once per frame

	void Update () {

		if (isDead)
			return;

		if (highscor >= highscoreToNextLevel)
			LevelUp();

		highscor += Time.deltaTime * difficultyLevel;
		highscoreText.text = ((int)highscor).ToString();
	}

	void LevelUp(){

		if (difficultyLevel == maxDifficultylevel)
			return;

		highscoreToNextLevel *= 2;
		difficultyLevel++;
        //GetComponent<PlayerMotor>().

		//GetCompenent<PlayerMotor>().SetSpeed(difficultyLevel);

		Debug.Log (difficultyLevel);
	}

	public void OnDeath(){

        isDead = true;
        if(PlayerPrefs.GetFloat("Highscore") < highscor)
        {

        }

		PlayerPrefs.SetFloat("Highscore", highscor);
		//deathMenu.ToggelEndMenu (highscor);
	}
}