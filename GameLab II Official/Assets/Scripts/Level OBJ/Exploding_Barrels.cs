using UnityEngine;
using System.Collections;

public class Exploding_Barrels : MonoBehaviour {

	public float radius;
	public float power;
	public float upModifier;
	public float rotationSpeed;

	public Vector3 rotateBarrel;

	public int explodingDamage;

	private bool mayRot;

	void Start () {

	}
	
	void Update () {
	
		RotateBarrel ();

	}

	public void RotateBarrel (){
		float rotSpeed;
		if(mayRot == true){
			transform.Rotate(new Vector3(rotateBarrel.x = rotationSpeed * Time.deltaTime, rotateBarrel.y = rotationSpeed * Time.deltaTime, rotateBarrel.z = rotationSpeed * Time.deltaTime));
		}
	}

	public void Explode (){

		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders){
			Rigidbody rb = hit.GetComponent<Rigidbody>();
			if(rb != null){
				rb.AddExplosionForce(power, explosionPos, radius, upModifier);
				mayRot = true;
				if(hit.transform.name == "Player"){
					GivePlayerDamage();
				}
			}
		}
		//Destroy(gameObject, 0.3f);
	}

	public void GivePlayerDamage (){
		GameObject.Find("Player").GetComponent<Health_TakeDamage_HitLocation>().HealthCalculator(explodingDamage);
		if(GameObject.Find("Player").GetComponent<Health_TakeDamage_HitLocation>().shieldActivated == true){
			GameObject.Find("Player").GetComponent<Health_TakeDamage_HitLocation>().shieldAmount -= 90f;
		}
	}

	public void GiveEnemyDamage (){
		
	}

	public void OnCollisionEnter (Collision col){

		if(col.transform.name == "Grond"){
			mayRot = false;
		}
	}
}
