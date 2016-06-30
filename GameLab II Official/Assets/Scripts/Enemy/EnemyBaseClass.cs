using UnityEngine;
using System.Collections;

public class EnemyBaseClass : MonoBehaviour {

	public	int			enemyHealth = 10;
	public	GameObject	manager;
	//public	GameObject	lvlSpawner;		

	// Use this for initialization
	void Start () {
	manager = GameObject.Find("Level Manager");
	//lvlSpawner = GameObject.Find("LevelSpawnManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Health (int takenDamage) {
		enemyHealth  -= takenDamage;
		if(enemyHealth < 1){
			GetComponent<EnemieAnimation>().EnemyDead();
			Destroy(gameObject);
		}
	}

	public void Senddeath () {
		manager.GetComponent<Balancer>().enemyAmount--;
		manager.GetComponent<Balancer>().CheckDoor();
	}
}