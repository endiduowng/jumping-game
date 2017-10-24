using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlayerController player;

	public GameObject deathParticale;

	public GameObject respawnParticle;

	public int pointPenatyOnDeath;

	public float respawnDelay;

	private float gravityStore;

	public HealthManager healthManager;

	private CameraController cam;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

		cam = FindObjectOfType<CameraController> ();

		healthManager = FindObjectOfType<HealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		Instantiate (deathParticale, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer> ().enabled = false;
		cam.isFollowing = false;

		//gravityStore = player.GetComponent<Rigidbody2D> ().gravityScale;
		//player.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		//player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

		ScoreManager.AddPoints (-pointPenatyOnDeath);
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds (respawnDelay);
		//player.GetComponent<Rigidbody2D> ().gravityScale = gravityStore;
		player.transform.position = currentCheckpoint.transform.position;
		player.knockBackCount = 0;
		player.enabled = true;
		player.GetComponent<Renderer> ().enabled = true;

		healthManager.FullHealth ();
		healthManager.isDead = false;

		cam.isFollowing = true;

		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
	}
}
