using UnityEngine;
using System.Collections;

public class JumpPad : MonoBehaviour {

	private Rigidbody playerRb;

	public GameObject player;

	public float boost;
	public float boostForward;

	public enum BoostTypes {
		Trampoline,
		Boost,
	}

	public BoostTypes myBoostTypes;

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnCollisionEnter (Collision hit){

		if(hit.transform.tag == "Player"){
			playerRb = hit.transform.gameObject.GetComponent<Rigidbody>();
			player = GameObject.Find("PlayerTest(Clone)");
			JumpBoost();
		}
	}

	public void JumpBoost (){

		switch (myBoostTypes){

			case BoostTypes.Trampoline:
				playerRb.velocity = transform.up * boost;
			break;

			case BoostTypes.Boost:
				playerRb.velocity = new Vector3 (0, player.transform.position.y * boost * Time.deltaTime, boostForward * Time.deltaTime);
			break;

		}
	}
}
