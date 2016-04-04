using UnityEngine;
using System.Collections;

public class EnemyBody : MonoBehaviour {

	public float damageModifier;
	public float calculatedDamage;
	public GameObject mainEnemy;
	public EnemyBaseClass enemyMainHealth;

	public void Damage(float givenDamage){
		//mainEnemy = GameObject.FindGameObjectWithTag("EnemyMain");
		mainEnemy = transform.parent.gameObject;
		enemyMainHealth = mainEnemy.GetComponent<EnemyBaseClass>();
		calculatedDamage = givenDamage * damageModifier;
		int roundedDamage = Mathf.CeilToInt(calculatedDamage);
		enemyMainHealth.Health(roundedDamage);
	}
}
