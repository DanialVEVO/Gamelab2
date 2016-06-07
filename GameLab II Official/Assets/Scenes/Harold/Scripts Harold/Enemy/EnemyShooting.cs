using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public Transform playerTarget;
	public GameObject enemyProjectile;
	public float shootCoolDown;
	public float shootCoolDownReset;

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
		//Instantiate(enemyProjectile, transform.position, transform.rotation);
		print("pew pew pew");
	}
}
