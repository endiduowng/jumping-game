using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	private LevelManager levelManager;

	private LifeManager lifeSystem;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();

		lifeSystem = FindObjectOfType<LifeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			levelManager.RespawnPlayer ();
			lifeSystem.TakeLife ();
		}
	}
}
