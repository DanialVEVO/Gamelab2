using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	public GameObject enemyShooter;
	//public Vector3 rotation;

	void Start () {
		Vector3 rotation = transform.eulerAngles;
		float randomNum = Random.Range(-0.01F, 0.01F);
		rotation.y += randomNum;
		rotation.x += randomNum;
		transform.eulerAngles = rotation;
	}
}
