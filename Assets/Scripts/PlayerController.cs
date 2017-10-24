using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float moveVelocity;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	public bool grounded;

	public bool doubleJumped;

	private Animator anim;

	public Transform firePoint;
	public GameObject ninjaStar;

	public float shootDelay;
	public float shootDelayCounter;

	public AudioSource jump;

	private Rigidbody2D myRigidbody2D;

	public float knockBack;
	public float knockBackCount;
	public float knockBackLength;
	public bool knockFromRight;

	public bool onLadder;
	public float climbSpeed;
	private float climVelocity;
	private float gravityStore;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		myRigidbody2D = GetComponent<Rigidbody2D> ();

		// luu lai gravity scale
		gravityStore = myRigidbody2D.gravityScale;
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {
		if (grounded) {
			doubleJumped = false;
		}

		anim.SetBool ("Grounded", grounded);

		#if UNITY_STANDALONE || UNITY_WEBPLAYER

		if (Input.GetButtonDown("Jump") && grounded) {
			//myRigidbody2D.velocity = new Vector2 (myRigidbody2D.velocity.x, jumpHeight);
			Jump();
		}

		if (Input.GetButtonDown("Jump") && !grounded && !doubleJumped) {
			//myRigidbody2D.velocity = new Vector2 (myRigidbody2D.velocity.x, jumpHeight);
			Jump();
			doubleJumped = true;
		}


		/*moveVelocity = 0f;

		if (Input.GetKey (KeyCode.RightArrow)) {
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = moveSpeed;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = -moveSpeed;
		}*/

		//moveVelocity = moveSpeed * Input.GetAxisRaw ("Horizontal");

		Move (Input.GetAxisRaw("Horizontal"));
		#endif

		if (knockBackCount <= 0) {
			myRigidbody2D.velocity = new Vector2 (moveVelocity, myRigidbody2D.velocity.y);
		} else {
			if (knockFromRight) {
				myRigidbody2D.velocity = new Vector2 (-knockBack, knockBack);
			} else {
				myRigidbody2D.velocity = new Vector2 (knockBack, knockBack);
			}
			knockBackCount -= Time.deltaTime;
		}

		anim.SetFloat ("Speed", Mathf.Abs(myRigidbody2D.velocity.x));
	
		if (myRigidbody2D.velocity.x > 0) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} else if (myRigidbody2D.velocity.x < 0) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
		#if UNITY_STANDALONE || UNITY_WEBPLAYER

		if (Input.GetButtonDown("Fire1")) {
			//Instantiate (ninjaStar, firePoint.transform.position, firePoint.transform.rotation);
			FireStar();
			shootDelayCounter = shootDelay;
		}
		// check truong hop giu im nut ban
		if (Input.GetButtonDown("Fire1")) {
			shootDelayCounter -= Time.deltaTime;
			if (shootDelayCounter <= 0) {
				shootDelayCounter = shootDelay;
				//Instantiate (ninjaStar, firePoint.transform.position, firePoint.transform.rotation);
				FireStar();
			}
		}

		if (anim.GetBool ("Sword")) {
			//anim.SetBool ("Sword", false);
			ResetWord();
		}
		if (Input.GetButtonDown("Fire2")) {
			//anim.SetBool ("Sword", true);
			Sword();
		}

		#endif

		if (onLadder) {
			myRigidbody2D.gravityScale = 0f;
			climVelocity = climbSpeed * Input.GetAxisRaw ("Vertical");
			myRigidbody2D.velocity = new Vector2 (myRigidbody2D.velocity.x, climVelocity);
		}

		if (!onLadder) {
			myRigidbody2D.gravityScale = gravityStore;
		}
	}

	public void Move(float moveInput){
		moveVelocity = moveInput * moveSpeed;
	}

	public void FireStar(){
		Instantiate (ninjaStar, firePoint.transform.position, firePoint.transform.rotation);
	}

	public void Sword(){
		anim.SetBool ("Sword", true);
	}

	public void ResetWord(){
		anim.SetBool ("Sword", false);
	}

	public void Jump(){
		if (grounded) {
			myRigidbody2D.velocity = new Vector2 (myRigidbody2D.velocity.x, jumpHeight);
		}

		if (!grounded && !doubleJumped) {
			myRigidbody2D.velocity = new Vector2 (myRigidbody2D.velocity.x, jumpHeight);
			doubleJumped = true;
		}
		jump.Play ();
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}
}
