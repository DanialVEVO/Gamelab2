using UnityEngine;
using System.Collections;

public class Charachter_Controller : MonoBehaviour {

	public int moveSpeed;			
	public int newSpeed;				
	public int oldSpeed;
	public int upgradeLevelCharachter;
	public int upgradePoints;

	public float mouseSpeedHor, mouseSpeedVer;
	public float limit;
	public float rayDistance, rayDistanceMelee;
	public float jumpSpeed;
	public float groundDistance;
	public float camFOV;
	public float minFOV, maxFOV;
	public float camFOVMultiplier;

	public bool mayJump;
	public bool mayUpgrade;

	public RaycastHit meleeRayHit;
	public Rigidbody playerRB;
	public GameObject mainCam;

	private float camRot;

	void Start (){

		playerRB = GetComponent<Rigidbody>();
		mainCam = GameObject.Find("Main Camera");
		mayUpgrade = true;

	}

	void Update () {

		Sprint();
		MovementControlls ();				
		CamRotHorizontal ();
		Melee ();
		CamRotVertical();
		GameOver();

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


	public void UpgradesCharachter (){

		if(mayUpgrade == true && upgradePoints >= 1){
			upgradeLevelCharachter += 1;
			upgradePoints -= 1;
		}
		CharachterUpgradesManager(upgradeLevelCharachter);

	}

	public void CharachterUpgradesManager (int upgradeLevelMC){

		switch (upgradeLevelMC){

			case 1 :
				moveSpeed = 8;
				newSpeed = 12;
				oldSpeed = 8;
				break;

			case 2 :
				moveSpeed = 10;
				newSpeed = 13;
				oldSpeed = 10;
				jumpSpeed = 400;
				break;

			case 3 : 
				moveSpeed = 12;
				newSpeed = 14;
				oldSpeed = 12;
				jumpSpeed = 400;
				break;

			case 4 :
				moveSpeed = 12;
				newSpeed = 14;
				oldSpeed = 12;
				jumpSpeed = 450;
				mayUpgrade = false;
				break;
		}
	}

	void MovementControlls (){

		if (Input.GetAxis ("Vertical") > 0) {															
			if (Physics.Raycast (transform.position, transform.forward, rayDistance)) {
			}
			else {
				transform.Translate (Vector3.forward * moveSpeed * Input.GetAxis ("Vertical") * Time.deltaTime);
			}
		}

		if (Input.GetAxis ("Vertical") < 0) {
			if (Physics.Raycast (transform.position, -transform.forward, rayDistance)) {
			} 
			else {
				transform.Translate (Vector3.back * moveSpeed * -Input.GetAxis ("Vertical") * Time.deltaTime);
			}
		}

		if (Input.GetAxis ("Horizontal") > 0) {
			if (Physics.Raycast (transform.position, transform.right, rayDistance)) {
			} 
			else {
				transform.Translate (Vector3.right * moveSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime);
			}
		}

		if (Input.GetAxis ("Horizontal") < 0) {
			if (Physics.Raycast (transform.position, -transform.right, rayDistance)) {
			} 
			else {
				transform.Translate (Vector3.left * moveSpeed * -Input.GetAxis ("Horizontal") * Time.deltaTime);
			}
		}
	}

	public void Sprint (){

		mainCam.GetComponent<Camera>().fieldOfView = camFOV;

		if(Input.GetAxis("Vertical") > 0 && Input.GetButton("Sprint") || Input.GetAxis("Vertical") < 0 && Input.GetButton("Sprint") || Input.GetAxis("Horizontal") > 0 && Input.GetButton("Sprint")){		
			moveSpeed = newSpeed;
			camFOV -= camFOVMultiplier * Time.deltaTime;
			if(camFOV <  minFOV){
				camFOV = minFOV;
			}
		}
		else{
			moveSpeed = oldSpeed;
			camFOV += camFOVMultiplier * Time.deltaTime;
			if(camFOV > maxFOV){
				camFOV = maxFOV;
			}
		}
	}

	void CamRotHorizontal (){

		transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"),0) * Time.deltaTime * mouseSpeedHor);

	}

	void CamRotVertical (){

		camRot -= Input.GetAxis("Mouse Y") * mouseSpeedVer;
		camRot = Mathf.Clamp(camRot, -limit, limit);
		mainCam.transform.localRotation = Quaternion.Euler(camRot, 0, 0);

	}

	public void Melee (){

		if(Input.GetButtonDown("Melee")){
			print("Melee");
			if(Physics.Raycast (transform.position, transform.forward, out meleeRayHit, rayDistanceMelee)){
				if(meleeRayHit.transform.tag == "Enemy"){
					Destroy(meleeRayHit.transform.gameObject);
				}
			}
		}
	}

	public void GameOver (){

		if(GetComponent<Health_TakeDamage_HitLocation>().playerHealth < 0){
			print("GameOver");
		}
	}
}
