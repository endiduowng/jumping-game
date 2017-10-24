using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;

	public bool hittingWall;

	public Transform edgeCheck;
	public bool notAtEdge;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);

		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);

		if (hittingWall || !notAtEdge) {
			moveRight = !moveRight;
		}

		if (moveRight) {
			// di sang phai thi doi toa do cua WallCheck sang phai
			transform.localScale = new Vector3 (-1f, 1f, 1f);

			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			// di sang trai thi doi toa do cua WallCheck sang trai
			transform.localScale = new Vector3 (1f, 1f, 1f);

			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
	}
}
