using UnityEngine;
using System.Collections;

public class ExplodingBarrelTest : MonoBehaviour {

	public float raydis;

	public RaycastHit rayHit;

	void Start () {
	
	}
	
	void Update () {
		
		ShootRay ();

	}

	public void ShootRay (){
		if(Input.GetButtonDown("Fire1")){
			Debug.DrawRay(transform.position, transform.forward, Color.red, raydis);
			if(Physics.Raycast(transform.position, transform.forward, out rayHit, raydis)){
				if(rayHit.transform.tag == "Exploding Barrel"){
					rayHit.transform.gameObject.GetComponent<Exploding_Barrels>().Explode();
				}
			}
		}
	}
}
