using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[HideInInspector]
	public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

	[HideInInspector]
	public int score, coinScore, lifeScore;

	// Use this for initialization
	void Awake () {
		MakeSingleton ();
	}

	void Start() {
		InitializeVariables ();
	}

	void OnEnable(){
		SceneManager.sceneLoaded += LevelFinishedLoading;
	}

	void OnDisable(){
		SceneManager.sceneLoaded -= LevelFinishedLoading;
	}

	void LevelFinishedLoading(Scene scene, LoadSceneMode loadScene) {
		if (scene.name == "Gameplay") {
			if (gameRestartedAfterPlayerDied) {
				
				GamePlayController.instance.SetScore (score);
				GamePlayController.instance.SetCoinScore (coinScore);
				GamePlayController.instance.SetLifeScore (lifeScore);

				PlayerScore.scoreCount = score;
				PlayerScore.coinCount = coinScore;
				PlayerScore.lifeCount = lifeScore;

			} else if(gameStartedFromMainMenu){
				PlayerScore.scoreCount = 0;
				PlayerScore.coinCount = 0;
				PlayerScore.lifeCount = 2;

				GamePlayController.instance.SetScore (0);
				GamePlayController.instance.SetCoinScore (0);
				GamePlayController.instance.SetLifeScore (2);
			}
		
		}
	}

	void InitializeVariables(){

		if (!PlayerPrefs.HasKey ("Game Initialized")) {
			GamePreferences.SetEasyDifficultyState (0);
			GamePreferences.SetEasyDifficultyCoinScore (0);
			GamePreferences.SetEasyDifficultyScore (0);

			GamePreferences.SetMediumDifficultyState (1);
			GamePreferences.SetMediumDifficultyCoinScore (0);
			GamePreferences.SetMediumDifficultyScore (0);

			GamePreferences.SetHardDifficultyState (0);
			GamePreferences.SetHardDifficultyCoinScore (0);
			GamePreferences.SetHardDifficultyScore (0);

			GamePreferences.SetIsMusicOn (1);

			PlayerPrefs.SetInt ("Game Initialized", 135);
		}
	}
	
	// Update is called once per frame
	void MakeSingleton() {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void CheckGameStatus(int score, int coinScore, int lifeScore){

		if (lifeScore < 0) {

			if (GamePreferences.GetEasyDifficultyState () == 1) {
				int highScore = GamePreferences.GetEasyDifficultyScore ();
				int coinHighScore = GamePreferences.GetEasyDifficultyScore ();

				if (highScore < score)
					GamePreferences.SetEasyDifficultyScore (score);

				if (coinHighScore < coinScore)
					GamePreferences.SetEasyDifficultyCoinScore (coinScore);
			}

			if (GamePreferences.GetMediumDifficultyState () == 1) {
				int highScore = GamePreferences.GetMediumDifficultyScore ();
				int coinHighScore = GamePreferences.GetMediumDifficultyScore ();

				if (highScore < score)
					GamePreferences.SetMediumDifficultyScore (score);

				if (coinHighScore < coinScore)
					GamePreferences.SetMediumDifficultyCoinScore (coinScore);
			}

			if (GamePreferences.GetHardDifficultyState () == 1) {
				int highScore = GamePreferences.GetHardDifficultyScore ();
				int coinHighScore = GamePreferences.GetHardDifficultyScore ();

				if (highScore < score)
					GamePreferences.SetHardDifficultyScore (score);

				if (coinHighScore < coinScore)
					GamePreferences.SetHardDifficultyCoinScore (coinScore);
			}

			gameStartedFromMainMenu = false;
			gameRestartedAfterPlayerDied = false;

			GamePlayController.instance.GameOverShowPanel (score, coinScore);
		} else {
			this.score = score;
			this.coinScore = coinScore;
			this.lifeScore = lifeScore;

			gameStartedFromMainMenu = false;
			gameRestartedAfterPlayerDied = true;

			GamePlayController.instance.PlayerDiedRestartTheGame ();
		}
	}
}
