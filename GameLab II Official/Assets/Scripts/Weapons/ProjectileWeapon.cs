/* [Code]
 * Abstract Projectile Weapon Class
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

public class ProjectileWeapon : WeaponScript {

	public	enum	WeaponType{
						Launcher
					}
	public	WeaponType	myWeaponType;

	public	bool		allowFire = true;
	public	bool		reloading = false;
	public	bool		allowAltFire = false;

	private float		rateOfFire;
	public	float		fireRatePerMinute;
	public 	float 		cooldown = 0;
	public	float		fireSpeed = 25f;

	public	int			loadedMagazine = 6;
	public 	int 		maxMagazineSize = 6;
	public	int			ammoPool = 12;
	public	int			maxPool= 48;
	public	int			damage = 1;  //check for remove

	public	RaycastHit	hit;

	public	Transform	muzzle;

	//Grenade/Rocket Launcher
	public 	GameObject	grenade;
	public	GameObject	rocket;


	//Alt fire stats
	public	int			altDamage = 2; //check for remove
	public	float		altFireSpeed = 100f;

	//Spread stats
	public 	float		xSpreadMin = 0f;
	public	float		xSpreadMax = 0f;
	public	float		YspreadMin = 0f;
	public	float		YspreadMax = 0f;

	// public	float[]		UpgradeVariables = new float[8];
	public float[]		upgradeVariables = new float[8];		

	void Start(){

		CalcRateOfFire();
		CalcUpgradeArray();
	}

	void FixedUpdate(){

		if(Input.GetButton("Fire1")){
			if(allowFire == true){
				allowFire = false;
				FireProjectile(fireSpeed, grenade);
			}
			else{
				//
			}
		}

		if(Input.GetButton("Fire2")){
			if(allowFire == true){
				AltFireExecute();
			}
		}
	}

	void Update(){
		if(Input.GetKeyDown("j")){
			CalcAmmoPool(-220);
		}

		if(allowFire == false){
			Cooldown();
		}



		if(Input.GetButtonDown("Reload")){
			if(reloading == false){
				Reload();
			}
			else{
				//
			}
		}
	}

	public override void Cooldown(){
		if(loadedMagazine > 0){
			if(!allowFire){
				cooldown -= Time.deltaTime;
				if(cooldown <= 0){
					allowFire = true;
					cooldown = rateOfFire;
				}
			}
		}
	}


	public override void FireBullets(){
		
	}

	public override void FireProjectile(float power, GameObject explosive){
		allowFire = false;
		GameObject projectileInstance;
        projectileInstance = (GameObject)Instantiate(explosive, muzzle.position, muzzle.rotation);
        projectileInstance.GetComponent<Rigidbody>().velocity = muzzle.forward * power;
	    loadedMagazine --;
	}

	public override void Spread(){
	}

	public override void SpreadReset(){
	}

	public override void Reload(){
		int neededAmmo;
		reloading = true;
		neededAmmo = (maxMagazineSize-loadedMagazine);
		CalcAmmoPool(neededAmmo);
		loadedMagazine += neededAmmo;
		reloading = false;
	}

	public override void AltFireExecute(){
		switch(myWeaponType){

			case WeaponType.Launcher :
				if(allowAltFire == true){
					FireProjectile(altFireSpeed, rocket);
				}
				// else{
				// 	//
				// }
				break;
			}
	}

	public override void AltFire(){
		switch(myWeaponType){

			case WeaponType.Launcher :
				//
				break;

		}
	}

	public override void GiveDamage(int sumDamage){

	}

	public override void CalcAmmoPool(int ammo){
		ammoPool -= ammo;
		ammoPool = Mathf.Clamp(ammoPool, 0,maxPool);
	}

	public override void SetAmmoPool(int poolUpgrade){
		ammoPool += poolUpgrade;
	}

	public override void CalcRateOfFire(){
		rateOfFire = 60/fireRatePerMinute;
		cooldown = rateOfFire;
		//print("The rate of fire is 1 bullet per " +rateOfFire +" second(s)");
	}

	public override void CalcUpgradeArray(){
		upgradeVariables[0] = (float)fireRatePerMinute;
		upgradeVariables[1] = (float)maxMagazineSize;
		upgradeVariables[2] = (float)maxPool;
		upgradeVariables[3] = (float)damage;
		upgradeVariables[4] = fireSpeed;
	}

	public override void SetUpgrades(){
		fireRatePerMinute	= (int)upgradeVariables[0];
		maxMagazineSize		= (int)upgradeVariables[1];
		maxPool				= (int)upgradeVariables[2];
		damage				= (int)upgradeVariables[3];
		fireSpeed			= upgradeVariables[4];

		CalcRateOfFire();
	}
}
