using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
	public int maxPlayerHealth;

	public static int playerHealth;

	//Text text;

	private LevelManager levelManager;

	private LifeManager lifeSystem;

	public bool isDead;

	private TimeManager theTime;

	public Slider healthBar;

	// Use this for initialization
	void Start () {
		//text = GetComponent<Text> ();

		//playerHealth = maxPlayerHealth;

		healthBar = GetComponent<Slider> ();

		playerHealth = PlayerPrefs.GetInt ("PlayerCurrentHealth");

		levelManager = FindObjectOfType<LevelManager> ();

		lifeSystem = FindObjectOfType<LifeManager> ();

		isDead = false;

		theTime = FindObjectOfType<TimeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0 && !isDead) {
			playerHealth = 0;
			levelManager.RespawnPlayer ();
			lifeSystem.TakeLife ();
			isDead = true;
			theTime.ResetTime ();
		}

		if (playerHealth > maxPlayerHealth) {
			playerHealth = maxPlayerHealth;
		}

		//text.text = "" + playerHealth;

		healthBar.value = playerHealth;
	}

	public static void HurtPlayer(int damageToGive){
		playerHealth -= damageToGive;
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
	}

	public void FullHealth(){
		//playerHealth = maxPlayerHealth;
		playerHealth = PlayerPrefs.GetInt ("PlayerMaxHealth");
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
	}

	public void KillPlayer(){
		playerHealth = 0;
	}
}
