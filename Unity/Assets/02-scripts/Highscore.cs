using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {
    public float highscore = 0.0f;
    private int difficultyLevel = 1;
    private int maxDifficultylevel = 10;
    private int highscoreToNextLevel = 10;

    private bool isDead = false;

    public Text highscoreText;

    public DeathMenu deathMenu;


    public void Start() {
        
    }
    //Update is calles once per frame

    void Update() {

        if (isDead)
            return;

        if (highscore >= highscoreToNextLevel)
            LevelUp();

        highscore += Time.deltaTime * difficultyLevel;
        highscoreText.text = ((int)highscore).ToString();
    }

    void LevelUp() {

        if (difficultyLevel == maxDifficultylevel)
            return;

        highscoreToNextLevel *= 2;
        difficultyLevel++;

        //GetCompenent<PlayerMotor>().SetSpeed(difficultyLevel);

        Debug.Log(difficultyLevel);
    }

    public void OnDeath() {

        isDead = true;
        if (PlayerPrefs.GetFloat("Highscore") < highscore) {

        }

    
        PlayerPrefs.SetFloat("Highscore", highscore);
        //deathMenu.ToggleEndMenu (highscore);
        
        PlayerPrefs.SetFloat("Highscore", highscore);
        deathMenu.ToggleEndMenu(this.highscore);
        
    }
}