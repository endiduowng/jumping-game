using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

	public int heartToGive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<PlayerController> () == null) {
			return;
		}
		HealthManager.HurtPlayer (heartToGive);
		Destroy (gameObject);
	}
}
