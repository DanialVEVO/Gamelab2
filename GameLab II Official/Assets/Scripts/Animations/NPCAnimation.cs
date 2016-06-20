using UnityEngine;
using System.Collections;

public class NPCAnimation : MonoBehaviour {

	public Animator anim;

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnTriggerEnter (Collider trigger) {

		if(trigger.transform.name == "PlayerTest"){
			anim.SetBool("IfDepspawn", false);
			anim.SetBool("IfSpawn", true);
			anim.SetBool("Idle", true);
		}
	}

	void OnTriggerExit (Collider trigger) {
		if(trigger.transform.name == "PlayerTest"){
			anim.SetBool("Idle", false);
			anim.SetBool("IfSpawn", false);
			anim.SetBool("IfDepspawn", true);
		}
	}
}
