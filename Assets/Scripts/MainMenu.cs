using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string startLevel;

	public string levelSelect;

	public int playerLives;

	public int playerHealth;

	public string level1Tag;

	public void NewGame(){

		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);

		PlayerPrefs.SetInt ("CurrentScore", 0);

		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);

		PlayerPrefs.SetInt (level1Tag, 1);

		Application.LoadLevel (startLevel);
		
	}

	public void LevelSelect(){
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);

		PlayerPrefs.SetInt ("CurrentScore", 0);

		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);

		PlayerPrefs.SetInt (level1Tag, 1);
		Application.LoadLevel (levelSelect);
	}

	public void QuitGame(){
		Debug.Log ("Game exited");
		Application.Quit ();
	}
}
