using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences {

	public static string EasyDifficulty = "EasyDifficulty";
	public static string MediumDifficulty = "MediumDifficulty";
	public static string HardDifficulty = "HardDifficulty";

	public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
	public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
	public static string HardDifficultyHighScore = "HardDifficultyHighScore";

	public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
	public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
	public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

	public static string IsMusicOn = "IsMusicOn";


	// NOTE we are going to use integers to represent boolean variables
	//0 - false, 1 - true

	//Music State

	public static void SetIsMusicOn(int state){
		PlayerPrefs.SetInt (GamePreferences.IsMusicOn, state);
	}

	public static int GetIsMusicOn(){
		return PlayerPrefs.GetInt (GamePreferences.IsMusicOn);
	}

	//Difficulty State

	public static void SetEasyDifficultyState(int difficulty){
		PlayerPrefs.SetInt (GamePreferences.EasyDifficulty, difficulty);
	}

	public static int GetEasyDifficultyState(){
		return PlayerPrefs.GetInt (GamePreferences.EasyDifficulty);
	}

	public static void SetMediumDifficultyState(int difficulty){
		PlayerPrefs.SetInt (GamePreferences.MediumDifficulty, difficulty);
	}

	public static int GetMediumDifficultyState(){
		return PlayerPrefs.GetInt (GamePreferences.MediumDifficulty);
	}

	public static void SetHardDifficultyState(int difficulty){
		PlayerPrefs.SetInt (GamePreferences.HardDifficulty, difficulty);
	}

	public static int GetHardDifficultyState(){
		return PlayerPrefs.GetInt (GamePreferences.HardDifficulty);
	}

	//Scores

	public static void SetEasyDifficultyScore(int score){
		PlayerPrefs.SetInt (GamePreferences.EasyDifficultyHighScore, score);
	}
		
	public static int GetEasyDifficultyScore(){
		return PlayerPrefs.GetInt (GamePreferences.EasyDifficultyHighScore);
	}

	public static void SetMediumDifficultyScore(int score){
		PlayerPrefs.SetInt (GamePreferences.MediumDifficultyHighScore, score);
	}

	public static int GetMediumDifficultyScore(){
		return PlayerPrefs.GetInt (GamePreferences.MediumDifficultyHighScore);
	}

	public static void SetHardDifficultyScore(int score){
		PlayerPrefs.SetInt (GamePreferences.HardDifficultyHighScore, score);
	}

	public static int GetHardDifficultyScore(){
		return PlayerPrefs.GetInt (GamePreferences.HardDifficultyHighScore);
	}

	//Coins

	public static void SetEasyDifficultyCoinScore(int coinScore){
		PlayerPrefs.SetInt (GamePreferences.EasyDifficultyCoinScore, coinScore);
	}

	public static int GetEasyDifficultyCoinScore(){
		return PlayerPrefs.GetInt (GamePreferences.EasyDifficultyCoinScore);
	}

	public static void SetMediumDifficultyCoinScore(int coinScore){
		PlayerPrefs.SetInt (GamePreferences.MediumDifficultyCoinScore, coinScore);
	}

	public static int GetMediumDifficultyCoinScore(){
		return PlayerPrefs.GetInt (GamePreferences.MediumDifficultyCoinScore);
	}

	public static void SetHardDifficultyCoinScore(int coinScore){
		PlayerPrefs.SetInt (GamePreferences.HardDifficultyCoinScore, coinScore);
	}

	public static int GetHardDifficultyCoinScore(){
		return PlayerPrefs.GetInt (GamePreferences.HardDifficultyCoinScore);
	}

}
