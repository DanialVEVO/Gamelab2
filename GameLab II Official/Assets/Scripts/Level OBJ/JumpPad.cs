using UnityEngine;
using System.Collections;

public class JumpPad : MonoBehaviour {

	private Rigidbody playerRb;

	public float boost;

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnCollisionEnter (Collision hit){

		if(hit.transform.tag == "Player"){
			playerRb = hit.transform.gameObject.GetComponent<Rigidbody>();
			JumpBoost();
		}
	}

	public void JumpBoost (){

		playerRb.velocity = new Vector3(0, boost, 0);


	}
}
