/* [Code]
 * Explosives Class
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

public class ExplosiveProjectileScript : MonoBehaviour {

	public	enum		Explosives{
							Grenade,
							Rocket,
						}
	public	Explosives	myExplosiveType;

	public	float		fuseTimer = 3f;
	public	float		power = 50;
	public	float		radius = 25;
	public	float		playerDamage = 20f;

	public	int			enemyDamage = 10;

	public	GameObject	particle;

	public	RaycastHit	hit;


	// Use this for initialization
	void Start(){

		

	}
	
	// Update is called once per frame
	void Update(){
		IdentifyMe();		
	}

	public void IdentifyMe(){
		switch(myExplosiveType){

			case Explosives.Grenade :
				Grenade();

				break;

			case Explosives.Rocket :
				Rocket();

				break;
		}

	}

	public void Grenade(){
		//print("myExplosiveType");
		fuseTimer -= Time.deltaTime;
		if(fuseTimer <= 0){
			GrenadeExplode();
		}
	}

	public void Rocket(){
		//print("myExplosiveType");
	}

	public void GrenadeExplode(){
		Explode();
		// Destroy(gameObject);
	}

	public void RocketExplode(){

	}

	public void Explode(){
		Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach(Collider hit in colliders){
            Rigidbody rb = hit.GetComponent<Rigidbody>();
			if(rb != null){
				rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
			} else {
				continue;
			}
			if(rb.transform.tag == "Enemy" || rb.transform.tag == "FlyingEnemy"){
				GiveEnemyDamage(enemyDamage, rb);
			}

			if(rb.transform.tag == "Player"){
				GivePlayerDamage(playerDamage, rb);
			}
		}
		DestroyMe();
	}

	public void DestroyMe(){
		Destroy(gameObject);
	}

	public void GiveEnemyDamage(int damage, Rigidbody rb){
		rb.transform.GetComponent<EnemyBaseClass>().Health(damage);
	}

	public void GivePlayerDamage(float damage, Rigidbody rb){
		rb.transform.GetComponent<Health_TakeDamage_HitLocation>().HealthCalculator(damage);
	}


}
