using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	public	Transform	targetPoint;
	public	float		pushStength = 7;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void OnTriggerEnter (Collider trigger){
		if(trigger.transform.tag == "Player"){
			trigger.transform.position = targetPoint.position;
			trigger.transform.rotation = targetPoint.rotation;
			trigger.GetComponent<Rigidbody>().velocity = targetPoint.forward * pushStength;
		}
	}
}