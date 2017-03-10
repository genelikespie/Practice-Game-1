using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

	[SerializeField]
	private Text scoreText, coinText;


	// Use this for initialization
	void Start () {
		SetScoreBasedOnDifficulty ();
	}

	void SetScore(int score, int coinScore){
		scoreText.text = score.ToString ();
		coinText.text = coinScore.ToString ();
	}

	void SetScoreBasedOnDifficulty(){
		if (GamePreferences.GetEasyDifficultyState () == 1)
			SetScore (GamePreferences.GetEasyDifficultyScore (), GamePreferences.GetEasyDifficultyCoinScore());
		if (GamePreferences.GetMediumDifficultyState () == 1)
			SetScore (GamePreferences.GetMediumDifficultyScore (), GamePreferences.GetMediumDifficultyCoinScore());
		if (GamePreferences.GetHardDifficultyState () == 1)
			SetScore (GamePreferences.GetHardDifficultyScore (), GamePreferences.GetHardDifficultyCoinScore());
	}
	public void GoBackMainMenu(){
		Application.LoadLevel("Main Menu");
	}
}
