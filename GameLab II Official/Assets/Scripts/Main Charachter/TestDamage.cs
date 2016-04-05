using UnityEngine;
using System.Collections;

public class TestDamage : MonoBehaviour {

	public float damage;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void OnTriggerEnter (Collider trigger){

		if(trigger.transform.tag == "Player"){
			trigger.gameObject.GetComponent<Health_TakeDamage_HitLocation>().HealthCalculator(damage);
			if(trigger.gameObject.GetComponent<Health_TakeDamage_HitLocation>().shieldActivated == true){
				trigger.gameObject.GetComponent<Health_TakeDamage_HitLocation>().shieldAmount -= 25f;
				GameObject.Find("ShieldBar").GetComponent<HudBar>().DamageCheck(25f);
			}
		}
	}
}
