using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	public Transform targetPoint;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void OnTriggerEnter (Collider trigger){
		if(trigger.transform.tag == "Player"){
			trigger.transform.position = targetPoint.position;
		}
	}
}