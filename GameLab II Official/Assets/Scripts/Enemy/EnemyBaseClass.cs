using UnityEngine;
using System.Collections;

public class EnemyBaseClass : MonoBehaviour {

public int	hp = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Health (int takenDamage) {
		hp -= takenDamage;
		if(hp < 1){
			GetComponent<EnemieAnimation>().EnemyDead();
			Destroy(gameObject);
		}
	}
}
