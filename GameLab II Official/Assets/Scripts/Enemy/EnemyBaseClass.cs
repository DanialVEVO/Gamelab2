/* [Code]
 * Enemy Base Class
 * Scripted by Danial
 */
using UnityEngine;
using System.Collections;

public class EnemyBaseClass : MonoBehaviour {

	public	int			enemyHealth = 10;
	[Range(0,100)]
	public	int			dropChance = 1;

	public	GameObject	manager;

	void Start () {
		manager = GameObject.Find("Level Manager");
	}
	
	void Update () {
		//vvv Delete these lines of code BETWEEN the commentsin the update function when testing loot drop is a success vvv
		if(enemyHealth < 1){
			SendDeath();
			Destroy(gameObject);
		}
		//^^^end of marking^^^
	}

	public void Health (int takenDamage) {
		enemyHealth  -= takenDamage;
		print(enemyHealth);
		if(enemyHealth < 1){
			GetComponent<EnemieAnimation>().EnemyDead();
			SendDeath();
			Destroy(gameObject);
		}
	}

	int CalcChance () {
		int rolledChance = Random.Range(0, 100);
		return rolledChance;
	}

	Vector3 Coords () {
		Vector3 myLocation = transform.position;
		return myLocation;
	}

	public void SendDeath () {
		manager.GetComponent<Balancer>().enemyAmount--;
		manager.GetComponent<Balancer>().CheckDoor();
		if(CalcChance() <= dropChance){
			manager.GetComponent<LootDropper>().Drop(Coords());
		}
	}

}