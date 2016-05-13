using UnityEngine;
using UnityEditor.Animations;
using System.Collections;

public class FiringTest2 : MonoBehaviour {

	public GameObject particle;
	public Transform muzzle;
	public Animator anim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey("f")){
			print("wow");
			Instantiate(particle, muzzle.position, muzzle.rotation);
			anim.SetTrigger("Ifshoot");
	}	
		if (Input.GetKeyUp ("f")) {
			anim.SetTrigger ("BackToIdle");
		}
	}
}
