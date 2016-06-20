//Gemaakt door Harold

using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	public GameObject enemyShooter;
	public int bulletDamage;
	public Rigidbody rb;
	public float bulletSpeed;
	//public Vector3 rotation;

	void Start () {
		rb = GetComponent<Rigidbody>();
		Vector3 rotation = transform.eulerAngles;
		float randomNum = Random.Range(-0.001F, 0.001F);
		rotation.y += randomNum;
		rotation.x += randomNum;
		//rotation.z = transform.rotation.z;
		transform.eulerAngles = rotation;
		rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
	}

	void Update(){
		rb.velocity = new Vector3(0, bulletSpeed, 0);
	}

	void OnCollisionEnter(Collision hit){
		if(hit.transform.tag == "Player"){
			DealDamage(bulletDamage);
			Destroy(gameObject);
		}
		else{
			Destroy(gameObject);
		}
	}

	void DealDamage(int damage){
		
	}
}