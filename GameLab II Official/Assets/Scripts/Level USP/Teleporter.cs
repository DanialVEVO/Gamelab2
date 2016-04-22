using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	public Transform [] teleporterPositions;

	public int randomChecker;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void OnTriggerEnter (Collider trigger){
		if(trigger.transform.tag == "Player"){
				randomChecker = Random.Range(0, teleporterPositions.Length);
				trigger.transform.position = teleporterPositions[randomChecker].position;
		}
	}
}