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
		Debug.Log(takenDamage);
		hp -= takenDamage;
		if(hp < 1){
			Destroy(gameObject);
		}
	}
}
