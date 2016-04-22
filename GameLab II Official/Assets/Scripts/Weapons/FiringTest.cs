using UnityEngine;
using System.Collections;

public class FiringTest : MonoBehaviour {

	public GameObject particle;
	public Transform muzzle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("f")){
			print("wow");
			Instantiate(particle, muzzle.position, muzzle.rotation);
		}
	
	}
}
