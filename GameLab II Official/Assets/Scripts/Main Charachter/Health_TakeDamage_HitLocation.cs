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

	public Transform enemyPos;

	void Start () {

		playerHealth = maxHealth;
		shieldActivated = true;
		mayUpgrade = true;
		enemyPos = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
	}
	
	void Update () {

		Shield ();

		if(playerHealth > maxHealth){
			playerHealth = maxHealth;
		}

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

	public void HitLocation (bool checkHit){
		if(checkHit == true){
			Vector3 forward = transform.TransformDirection(Vector3.forward);
			Vector3 right = transform.TransformDirection(Vector3.right);
			Vector3 enemyDis = enemyPos.position - transform.position;
			if(Vector3.Dot(forward, enemyDis) < 0){
				print("HitBack");
			}
			if(Vector3.Dot(forward, enemyDis) > 0){
				print("HitFront");
			}
			if(Vector3.Dot(right, enemyDis) < 0){
				print("HitLeft");
			}
			if(Vector3.Dot(right, enemyDis) > 0){
				print("HitRight");
			}
		}
	}
}
