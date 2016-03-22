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
			for(int i = 0; i < teleporterPositions.Length; i ++){
				randomChecker = Random.Range(0, teleporterPositions.Length);
				if(i == randomChecker){
					trigger.transform.position = teleporterPositions[i].position;
				}
			}
		}
	}
}