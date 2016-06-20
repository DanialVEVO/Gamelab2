//Gemaakt door Harold

using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public Transform playerTarget;
	public GameObject enemyProjectile;
	public float shootCoolDown;
	public float shootCoolDownReset;
	public Vector3 bulletRotation;

	void Start(){
		shootCoolDown = shootCoolDownReset;
	}

	void Update() {
		if(!Physics.Linecast(transform.position, playerTarget.position)){
			if(shootCoolDown >= 0){
				shootCoolDown -= Time.deltaTime;
			}
			else{
				Shoot();
				shootCoolDown =  shootCoolDownReset;
			}
		}
	}

	void Shoot(){
		//bulletRotation = transform.rotation;
		//float randomNum = Random.Range(-0.01, 0.01); 
		//bulletRotation.y+= randomNum;
		GameObject bullet = Instantiate(enemyProjectile, transform.position, transform.rotation) as GameObject;
		bullet.GetComponent<EnemyBullet>().enemyShooter = gameObject;
		print("pew pew pew");
	}
}
