using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStarController : MonoBehaviour {

	public float speed;

	public PlayerController player;

	//public GameObject enemyDeathEffect;

	public GameObject impactEffect;

	//public int pointForKill;

	public float rotationSpeed;

	public int damageToGive;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

		if (!player) {
			return;
		}else if (player.transform.position.x < transform.position.x) {
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);

		// toc do quay cua dan, tinh theo per second(bao nhieu vong tren giay)
		GetComponent<Rigidbody2D> ().angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.name == "Player") {
			//Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy (other.gameObject);
			//ScoreManager.AddPoints (pointForKill);
			HealthManager.HurtPlayer(damageToGive);
		}

		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
