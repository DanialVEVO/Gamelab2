using UnityEngine;
using System.Collections;

public class HitlocationTest : MonoBehaviour {

	public float rayDis;

	public bool checkHitBool;

	public RaycastHit rayHit;

	void Start () {
	
	}
	
	void Update () {
		
		ShootRaycast();

	}

	public void ShootRaycast (){

		if(Physics.Raycast(transform.position, Vector3.forward, out rayHit, rayDis)){
			if(rayHit.transform.tag == "Player"){
				checkHitBool = true;
				rayHit.transform.gameObject.GetComponent<Health_TakeDamage_HitLocation>().HitLocation(checkHitBool);
			}
			else{
				checkHitBool = false;
				rayHit.transform.gameObject.GetComponent<Health_TakeDamage_HitLocation>().HitLocation(checkHitBool);
			}
		}
	}
}
