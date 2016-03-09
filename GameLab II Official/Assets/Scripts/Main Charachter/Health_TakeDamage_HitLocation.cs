using UnityEngine;
using System.Collections;

public class Health_TakeDamage_HitLocation : MonoBehaviour {

	public int maxHealth;
	public int shield;
	public int playerHealth;

	public float shieldRecharge;
	public float rechargeSpeed;
	public float shieldAmount;
	public float maxShield;

	public bool shieldActivated;
	public bool mayRecharge;

	void Start () {

		playerHealth = maxHealth;
		shieldActivated = true;

	}
	
	void Update () {

		Shield ();

	}

	public void HealthCalculator (int damagePlayer){

		if(shieldActivated == true){
			playerHealth -= damagePlayer / shield;
		}

		else{
			playerHealth -= damagePlayer;
		}

		StartCoroutine(ShieldRecharge());
	}

	public void Shield (){

		if(shieldAmount > 0){
			shieldActivated = true;
		}
		else{
			shieldActivated = false;
		}

		if(mayRecharge == true){
			shieldAmount += rechargeSpeed * Time.deltaTime;
		}
		if(shieldAmount >= maxShield){
			shieldAmount = maxShield;
		}
		if(shieldAmount <= 0){
			shieldAmount = 0;
		}
	}

	public IEnumerator ShieldRecharge (){

		mayRecharge = false;
		yield return new WaitForSeconds(shieldRecharge);
		print("StartCoroutine");
		mayRecharge = true;
	}
}
