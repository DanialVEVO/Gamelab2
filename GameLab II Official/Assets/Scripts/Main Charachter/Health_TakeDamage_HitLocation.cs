using UnityEngine;
using System.Collections;

public class Health_TakeDamage_HitLocation : MonoBehaviour {

	public float maxHealth;
	public float shield;
	public float playerHealth;
	public float shieldRecharge;
	public float rechargeSpeed;
	public float shieldAmount;
	public float maxShield;

	public bool mayUpgrade;
	public bool shieldActivated;
	public bool mayRecharge;

	public Transform enemyPos;

	public GameObject healthBar, shieldBar;

	void Start () {

		playerHealth = maxHealth;
		shieldActivated = true;
		mayUpgrade = true;
		enemyPos = GameObject.FindWithTag("Enemy").GetComponent<Transform>();

		healthBar = GameObject.Find("HealthBar");
		shieldBar = GameObject.Find("ShieldBar");

		healthBar.GetComponent<HudBar>().maxBarNumber = maxHealth;
		shieldBar.GetComponent<HudBar>().maxBarNumber = maxShield;
	}
	
	void Update () {

		healthBar.GetComponent<HudBar>().currentBarNumber = playerHealth;
		shieldBar.GetComponent<HudBar>().currentBarNumber = shieldAmount;

		Shield ();

		if(playerHealth > maxHealth){
			playerHealth = maxHealth;
		}

	}

	public void HealthCalculator (float damagePlayer){

		float finalDamage;

		if(shieldActivated == true){
			finalDamage = damagePlayer / shield;
			playerHealth -= finalDamage;
			healthBar.GetComponent<HudBar>().DamageCheck(finalDamage);
			shieldBar.GetComponent<HudBar>().DamageCheck(-shieldAmount);
		}

		else{
			playerHealth -= damagePlayer;
			healthBar.GetComponent<HudBar>().DamageCheck(damagePlayer);
		}

		StartCoroutine(ShieldRecharge());
	}

	public void Shield (){
		if(mayRecharge == false){
			shieldBar.GetComponent<HudBar>().DamageCheck(0f);
		}

		if(shieldAmount > 0){
			shieldActivated = true;
		}
		else{
			shieldActivated = false;
		}

		if(mayRecharge == true){
			shieldAmount += rechargeSpeed * Time.deltaTime;
			shieldBar.GetComponent<HudBar>().DamageCheck(-0f);
		}
		if(shieldAmount >= maxShield){
			mayRecharge = false;
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

	public void ShieldUpgradeManager (int upgradeLevel){

		switch (upgradeLevel){

			case 1 :
				maxShield = 110;
				shieldBar.GetComponent<HudBar>().maxBarNumber = maxShield;
				StartCoroutine(ShieldRecharge());
				break;

			case 2 :
				maxShield = 125;
				rechargeSpeed = 5;
				shield = 3;
				shieldBar.GetComponent<HudBar>().maxBarNumber = maxShield;
				StartCoroutine(ShieldRecharge());
				break;

			case 3 :
				maxShield = 150;
				rechargeSpeed = 5;
				shield = 3;
				shieldBar.GetComponent<HudBar>().maxBarNumber = maxShield;
				StartCoroutine(ShieldRecharge());
				break;

			case 4 :
				maxShield = 200;
				rechargeSpeed = 10;
				mayUpgrade = false;
				shield = 4;
				shieldBar.GetComponent<HudBar>().maxBarNumber = maxShield;
				StartCoroutine(ShieldRecharge());
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
