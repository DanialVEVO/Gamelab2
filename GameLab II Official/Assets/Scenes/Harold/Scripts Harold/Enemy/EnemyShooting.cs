//Gemaakt door Harold

using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public Transform playerTarget;
	public GameObject enemyProjectile;
	public float shootCoolDown;
	public float shootCoolDownReset;
	public Vector3 bulletRotation;
	public int enemyShootDamage;


	void Start(){
		shootCoolDown = shootCoolDownReset;
	}

	void Update() {
		if(Physics.Linecast(transform.position, playerTarget.position)){
			if(shootCoolDown >= 0){
				shootCoolDown -= Time.deltaTime;
			}
			else{
				Shoot();
				//shootCoolDown =  shootCoolDownReset;
			}
		}
	}

	void Shoot(){
		//bulletRotation = transform.rotation;
		//float randomNum = Random.Range(-0.01, 0.01); 
		//bulletRotation.y+= randomNum;
		Vector3 bulletPosition = transform.localPosition;
		bulletPosition.z+= 2;
		GameObject bullet = Instantiate(enemyProjectile, bulletPosition, transform.rotation) as GameObject;
		bullet.GetComponent<EnemyBullet>().enemyShooter = gameObject;
		bullet.GetComponent<EnemyBullet>().bulletDamage = enemyShootDamage;
		print("pew pew pew");
		shootCoolDown = shootCoolDownReset;
	}
}
