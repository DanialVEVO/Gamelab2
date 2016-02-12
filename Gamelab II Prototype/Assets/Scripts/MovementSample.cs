using UnityEngine;
using System.Collections;

public class MovementSample: MonoBehaviour {
		
	public int moveSpeed;			
	public int newSpeed;				
	public int oldSpeed;
	public int upgradeRun;
	public int upgradeMove;

	public float mouseSpeed;
	public float rayDistance;
	public float jumpSpeed;
	public float extraJumpSpeed;
	public float groundDistance;

	public bool mayJump;

	public Rigidbody playerRB;

	void Start (){
		playerRB = GetComponent<Rigidbody>();
	}

	void Update () {
		MovementControlls ();				
		CamRotHorizontal ();
	}

	void FixedUpdate (){
		Jump();
	}

	void Jump (){
		if(Physics.Raycast (transform.position, new Vector3 (0, -1, 0), groundDistance)){
			mayJump = true;
			if(Input.GetButtonDown("Jump") && mayJump == true){
				playerRB.velocity = new Vector3 (0, jumpSpeed * Time.deltaTime, 0);
			}
		}
		else{
			mayJump = false;
		}
	}


	public void UpgradesJump (){
		jumpSpeed += extraJumpSpeed;
	}

	public void UpgradesRun (){
		moveSpeed += upgradeMove;
		newSpeed += upgradeRun;
		oldSpeed += upgradeRun;
	}

	void MovementControlls (){
		if (Input.GetAxis ("Vertical") > 0) {															
			if (Physics.Raycast (transform.position, transform.forward, rayDistance)) {
				print ("Hit");
			}
			else {
				transform.Translate (Vector3.forward * moveSpeed * Input.GetAxis ("Vertical") * Time.deltaTime);
			}
		}

		if (Input.GetAxis ("Vertical") < 0) {
			if (Physics.Raycast (transform.position, -transform.forward, rayDistance)) {
				print ("Hit");
			} 
			else {
				transform.Translate (Vector3.back * moveSpeed * -Input.GetAxis ("Vertical") * Time.deltaTime);
			}
		}

		if (Input.GetAxis ("Horizontal") > 0) {
			if (Physics.Raycast (transform.position, transform.right, rayDistance)) {
				print ("Hit");
			} 
			else {
				transform.Translate (Vector3.right * moveSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime);
			}
		}

		if (Input.GetAxis ("Horizontal") < 0) {
			if (Physics.Raycast (transform.position, -transform.right, rayDistance)) {
				print ("Hit");
			} 
			else {
				transform.Translate (Vector3.left * moveSpeed * -Input.GetAxis ("Horizontal") * Time.deltaTime);
			}
		}

		if(Input.GetAxis("Vertical") > 0 && Input.GetButton("Sprint") || Input.GetAxis("Vertical") < 0 && Input.GetButton("Sprint") || Input.GetAxis("Horizontal") > 0 && Input.GetButton("Sprint")){				//Condition for sprinting;
			moveSpeed = newSpeed;
			GameObject.Find("Player/MainCamera").GetComponent<Camera>().fieldOfView = 60;
		}
		else{
			moveSpeed = oldSpeed;

		}
	}
	void CamRotHorizontal (){
		transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"),0) * Time.deltaTime * mouseSpeed);
	}
}
