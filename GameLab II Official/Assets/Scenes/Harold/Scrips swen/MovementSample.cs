using UnityEngine;
using System.Collections;

public class MovementSample: MonoBehaviour {

	public int moveSpeed;					//Int for MoveSpeed;
	public float rayDistance;				//Float for distance of Raycast;
	public int newSpeed;					//Int for the sprint Speed;
	public int oldSpeed;					//Int for resetting the MoveSpeed;
	public float mouseSpeed;

	void Update () {
		MovementControlls ();				//Calling Function MovementControlls;
		CamRotHorizontal ();
	}

	void MovementControlls (){
		if (Input.GetAxis ("Vertical") > 0) {																				//Calling the function Input. Also Calling Raycast function. Basic movement;
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
