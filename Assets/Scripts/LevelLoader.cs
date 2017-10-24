using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

	public bool playerInZone;

	public string levelToLoad;

	public string levelTag;

	// Use this for initialization
	void Start () {
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInZone && Input.GetAxisRaw("Vertical") > 0) {
			//Application.LoadLevel (levelToLoad);
			LoadLevel();
		}
	}

	public void LoadLevel(){
		PlayerPrefs.SetInt (levelTag, 1);
		Application.LoadLevel (levelToLoad);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			playerInZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.name == "Player") {
			playerInZone = false;
		}
	}
}
