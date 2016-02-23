using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	public Vector3 teleportPos;
	public float minPosX, maxPosX, minPosZ, maxPosZ, maxYPos;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void OnTriggerEnter (Collider trigger){
		if(trigger.transform.tag == "Player"){
			teleportPos.x = Random.Range (minPosX, maxPosX);
			teleportPos.y = maxYPos;
			teleportPos.z = Random.Range (minPosZ, maxPosZ);
			trigger.transform.position = teleportPos;
		}
	}
}
