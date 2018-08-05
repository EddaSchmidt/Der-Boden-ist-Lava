using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class highscore : MonoBehaviour {
	private float highscore = 0.0f;
	private int difficultyLevel = 1; 
	private int maxDifficultylevel =  10;
	private int highscoreToNextLevel = 10;

	private bool isDead = false;

	private Text highscoreText;
	public DeathMenu deathMenu;


	//Update is calles once per frame

	void Update () {

		if (isDead)
			return;

		if (highscore >= scoreToNextLevel)
			LevelUp();

		score += Time.deltaTime * difficultyLevel;
		scoreText.text = ((int)highscore).ToString();
	}

	void LevelUp(){

		if (difficultyLevel == maxDifficultyLevel)
			return;

		scoreToNextLevel *= 2;
		diffecultyLevel++;

		GetCompenent<PlayerMotor>(). SetSpeed (difficultyLevel);

		Debug.Log (difficultyLevel);
	}

	public void OnDeath(){ 

		isDead = true
		PlayerPrefs.Setfloat("Highscore", highscore);
		deathMenu.ToggelEndMenu (highscore);
	}
}