using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool doubleJumped;
	private Animator anim;
	private float moveVelocity;
	public Transform firePoint;
	public GameObject ninjaStar;
	public bool onLadder;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;

	//private Rigidbody2D myrigidbody2D;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		gravityStore = GetComponent<Rigidbody2D>().gravityScale;
		//myrigidbody2D = GetComponent<Rigidbody2D> ();
	}
	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

	}
	// Update is called once per frame
	void Update () {
		if (grounded)
			doubleJumped = false;
		if (Input.GetKeyDown (KeyCode.Space)&& grounded) {
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			Jump();
		}
		if (Input.GetKeyDown (KeyCode.Space)&& !doubleJumped && !grounded) {
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			Jump();
			doubleJumped = true;
		}
		moveVelocity = 0f;
		//Move(Input.GetAxisRaw("Horizontal"));

		if (Input.GetKey (KeyCode.D)) {
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity=moveSpeed;
		}
		if (Input.GetKey (KeyCode.A)) {
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity=-moveSpeed;
		}
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

		anim.SetFloat ("Speed", Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x));

		if (GetComponent<Rigidbody2D> ().velocity.x>0) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else if(GetComponent<Rigidbody2D> ().velocity.x<0){
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
		/*
		#if UNITY_STANDALONE || UNITY_WEBPLAYER
		Move(Input.GetAxisRaw("Horizontal"));
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			//Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			Fire();
		}

		#endif
		*/
		if (onLadder) {

			GetComponent<Rigidbody2D> ().gravityScale = 0f;
			climbVelocity = climbSpeed * Input.GetAxisRaw ("Vertical");
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, climbVelocity);
		}
		if (!onLadder) {
			GetComponent<Rigidbody2D> ().gravityScale = gravityStore;
		}

	}
	public void Move(float moveInput){
		moveVelocity = moveSpeed *(Input.GetAxisRaw("Horizontal"));
	}
	public void Fire(){
		Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
	}
	public void Jump(){
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
	}
	public void OnCollisionEnter2D(Collision2D other){
		if(other.transform.tag=="Movingplatform"){

			transform.parent=other.transform;
		}

	}

}
