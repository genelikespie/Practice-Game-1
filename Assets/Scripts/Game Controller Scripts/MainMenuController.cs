using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	[SerializeField]
	private Button musicBtn;


	[SerializeField]
	private Sprite[] musicIcons;


	// Use this for initialization
	void Start () {
		CheckToPlayTheMusic ();
	}

	void CheckToPlayTheMusic(){
		if (GamePreferences.GetIsMusicOn () == 1) {
			MusicController.instance.PlayMusic (true);
			musicBtn.image.sprite = musicIcons [1];
		} else {
			MusicController.instance.PlayMusic (false);
			musicBtn.image.sprite = musicIcons [0];
		}
	}
	
	public void StartGame(){
		GameManager.instance.gameStartedFromMainMenu = true;
		//Application.LoadLevel("Gameplay");
		SceneFader.instance.LoadLevel("Gameplay");
	}

	public void HighscoreMenu(){
		Application.LoadLevel("HighScore");
	}

	public void OptionsMenu(){
		Application.LoadLevel("OptionMenu");
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void MusicButton(){
		if (GamePreferences.GetIsMusicOn () == 0) {
			GamePreferences.SetIsMusicOn (1);
			MusicController.instance.PlayMusic (true);
			musicBtn.image.sprite = musicIcons [1];
		} else if (GamePreferences.GetIsMusicOn () == 1) {
			GamePreferences.SetIsMusicOn (0);
			MusicController.instance.PlayMusic (false);
			musicBtn.image.sprite = musicIcons [0];
		}
	}
}
