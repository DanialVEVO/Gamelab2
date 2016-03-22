using UnityEngine;
using System.Collections;

public class Exploding_Barrels : MonoBehaviour {

	public float radius;
	public float power;
	public float upModifier;

	public int explodingDamage;

	void Start () {

	}
	
	void Update () {
	
	}

	public void Explode (){

		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders){
			Rigidbody rb = hit.GetComponent<Rigidbody>();
			if(rb != null){
				rb.AddExplosionForce(power, explosionPos, radius, upModifier);
				if(hit.transform.name == "Player"){
					GivePlayerDamage();
				}
			}
		}
		Destroy(gameObject, 0.3f);
	}

	public void GivePlayerDamage (){
		GameObject.Find("Player").GetComponent<Health_TakeDamage_HitLocation>().HealthCalculator(explodingDamage);
		if(GameObject.Find("Player").GetComponent<Health_TakeDamage_HitLocation>().shieldActivated == true){
			GameObject.Find("Player").GetComponent<Health_TakeDamage_HitLocation>().shieldAmount -= 90f;
		}
	}

	public void GiveEnemyDamage (){
		
	}
}
