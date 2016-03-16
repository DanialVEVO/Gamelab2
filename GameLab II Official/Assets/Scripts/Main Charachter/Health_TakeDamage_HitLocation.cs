using UnityEngine;
using System.Collections;

public class Health_TakeDamage_HitLocation : MonoBehaviour {

	public int maxHealth;
	public int shield;
	public int playerHealth;
	public int upgradeLevelShield;

	public float shieldRecharge;
	public float rechargeSpeed;
	public float shieldAmount;
	public float maxShield;

	public bool mayUpgrade;
	public bool shieldActivated;
	public bool mayRecharge;

	void Start () {

		playerHealth = maxHealth;
		shieldActivated = true;
		mayUpgrade = true;

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
		print("Recharge");
		mayRecharge = true;
	}

	public void UpgradeShield (){

		if(mayUpgrade == true && GetComponent<Charachter_Controller>().upgradePoints >= 1){
			upgradeLevelShield += 1;
			GetComponent<Charachter_Controller>().upgradePoints -= 1;
		}
		ShieldUpgradeManager(upgradeLevelShield);

	}

	public void ShieldUpgradeManager (int upgradeLevel){

		switch (upgradeLevel){

			case 1 :
				maxShield = 110;
				break;

			case 2 :
				maxShield = 125;
				rechargeSpeed = 5;
				shield = 3;
				break;

			case 3 :
				maxShield = 150;
				rechargeSpeed = 5;
				shield = 3;
				break;

			case 4 :
				maxShield = 200;
				rechargeSpeed = 10;
				mayUpgrade = false;
				shield = 4;
				break;
		}
	}

	public void HitLocation (){
		
	}

	public void OnCollisionEnter (Collision hit){

	}
}
