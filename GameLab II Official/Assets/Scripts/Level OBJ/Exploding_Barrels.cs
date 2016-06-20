using UnityEngine;
using System.Collections;

public class Exploding_Barrels : MonoBehaviour {

	public float radius;
	public float power;
	public float upModifier;
	public float rotationSpeed;
	public float explodingDamage;

	public Vector3 rotateBarrel;

	private bool mayRot;

	public GameObject player;
	public GameObject explodeParticle;

	void Start () {

		player = GameObject.Find("Player(Clone)");

	}
	
	void Update () {
	
		RotateBarrel ();

	}

	public void RotateBarrel (){
		if(mayRot == true){
			transform.Rotate(new Vector3(rotateBarrel.x = rotationSpeed * Time.deltaTime, rotateBarrel.y = rotationSpeed * Time.deltaTime, rotateBarrel.z = rotationSpeed * Time.deltaTime));
		}
	}

	public void Explode (){

		Instantiate(explodeParticle, transform.position, Quaternion.identity);
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders){
			Rigidbody rb = hit.GetComponent<Rigidbody>();
			if(rb != null){
				rb.AddExplosionForce(power, explosionPos, radius, upModifier);
				mayRot = true;
				if(hit.transform.name == "PlayerTest(Clone)"){
					GivePlayerDamage();
				}
			}
		}
		//Destroy(gameObject, 0.3f);
	}

	public void GivePlayerDamage (){
		player.GetComponent<Health_TakeDamage_HitLocation>().HealthCalculator(explodingDamage);
		if(player.GetComponent<Health_TakeDamage_HitLocation>().shieldActivated == true){
			player.GetComponent<Health_TakeDamage_HitLocation>().shieldAmount -= 90f;
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
